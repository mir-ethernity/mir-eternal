using System;


namespace UpkManager.Dds.Compression {

  /*
  * The symmetric eigensystem solver algorithm is from
  * http://www.geometrictools.com/Documentation/EigenSymmetric3x3.pdf
  */

  internal static class Maths {

    #region Private Fields

    private const float FLT_EPSILON = 1.192092896e-07F; // This is not the same value as Single.Epsilon

    #endregion Private Fields

    #region Public Methods

    public static Sym3x3 ComputeWeightedCovariance(int n, Vec3[] points, float[] weights) {
      //
      // compute the centroid
      //
      float total = 0.0f;

      Vec3 centroid = new Vec3(0.0f);

      for(int i = 0; i < n; ++i) {
        total += weights[i];

        centroid += weights[i] * points[i];
      }

      centroid /= total;
      //
      // accumulate the covariance matrix
      //
      Sym3x3 covariance = new Sym3x3(0.0f);

      for(int i = 0; i < n; ++i) {
        Vec3 a = points[i] - centroid;

        Vec3 b = weights[i] * a;

        covariance[0] += a.X * b.X;
        covariance[1] += a.X * b.Y;
        covariance[2] += a.X * b.Z;
        covariance[3] += a.Y * b.Y;
        covariance[4] += a.Y * b.Z;
        covariance[5] += a.Z * b.Z;
      }
      //
      // return it
      //
      return covariance;
    }

    public static Vec3 ComputePrincipleComponent(Sym3x3 matrix) {
      //
      // compute the cubic coefficients
      //
      float c0 = matrix[0] * matrix[3] * matrix[5] + 2.0f * matrix[1] * matrix[2] * matrix[4] - matrix[0] * matrix[4] * matrix[4] - matrix[3] * matrix[2] * matrix[2] - matrix[5] * matrix[1] * matrix[1];

      float c1 = matrix[0] * matrix[3] + matrix[0] * matrix[5] + matrix[3] * matrix[5] - matrix[1] * matrix[1] - matrix[2] * matrix[2] - matrix[4] * matrix[4];

      float c2 = matrix[0] + matrix[3] + matrix[5];
      //
      // compute the quadratic coefficients
      //
      float a = c1 - 1.0f / 3.0f * c2 * c2;

      float b = -2.0f / 27.0f * c2 * c2 * c2 + 1.0f / 3.0f * c1 * c2 - c0;
      //
      // compute the root count check
      //
      float Q = 0.25f * b * b + 1.0f / 27.0f * a * a * a;
      //
      // test the multiplicity
      //
      if (FLT_EPSILON < Q) return new Vec3(1.0f); // only one root, which implies we have a multiple of the identity

      if (Q < -FLT_EPSILON) {
        //
        // three distinct roots
        //
        float theta = (float)Math.Atan2(Math.Sqrt(-Q), -0.5f * b);

        float rho = (float)Math.Sqrt(0.25f * b * b - Q);

        float rt = (float)Math.Pow(rho, 1.0f / 3.0f);
        float ct = (float)Math.Cos(theta / 3.0f);
        float st = (float)Math.Sin(theta / 3.0f);

        float l1 = 1.0f / 3.0f * c2 + 2.0f * rt * ct;
        float l2 = 1.0f / 3.0f * c2 - rt * (ct + (float)Math.Sqrt(3.0f) * st);
        float l3 = 1.0f / 3.0f * c2 - rt * (ct - (float)Math.Sqrt(3.0f) * st);
        //
        // pick the larger
        //
        if (Math.Abs(l2) > Math.Abs(l1)) l1 = l2;
        if (Math.Abs(l3) > Math.Abs(l1)) l1 = l3;
        //
        // get the eigenvector
        //
        return GetMultiplicity1Evector(matrix, l1);
      }
      else {
        //
        // two roots
        //
        float rt;

        if (b < 0.0f) rt = -(float)Math.Pow(-0.5f * b, 1.0f / 3.0f);
        else rt = (float)Math.Pow(0.5f * b, 1.0f / 3.0f);

        float l1 = 1.0f / 3.0f *c2 + rt; // repeated
        float l2 = 1.0f / 3.0f *c2 - 2.0f * rt;
        //
        // get the eigenvector
        //
        return Math.Abs(l1) > Math.Abs(l2) ? GetMultiplicity2Evector(matrix, l1) : GetMultiplicity1Evector(matrix, l2);
      }
    }

    #endregion Public Methods

    #region Private Methods

    private static Vec3 GetMultiplicity1Evector(Sym3x3 matrix, float evalue) {
      //
      // compute M
      //
      Sym3x3 m = new Sym3x3 {
        [0] = matrix[0] - evalue,
        [1] = matrix[1],
        [2] = matrix[2],
        [3] = matrix[3] - evalue,
        [4] = matrix[4],
        [5] = matrix[5] - evalue
      };
      //
      // compute U
      //
      Sym3x3 u = new Sym3x3 {
        [0] = m[3] * m[5] - m[4] * m[4],
        [1] = m[2] * m[4] - m[1] * m[5],
        [2] = m[1] * m[4] - m[2] * m[3],
        [3] = m[0] * m[5] - m[2] * m[2],
        [4] = m[1] * m[2] - m[4] * m[0],
        [5] = m[0] * m[3] - m[1] * m[1]
      };
      //
      // find the largest component
      //
      float mc = Math.Abs(u[0]);

      int mi = 0;

      for(int i = 1; i < 6; ++i) {
        float c = Math.Abs(u[i]);

        if (c > mc) {
          mc = c;
          mi = i;
        }
      }
      //
      // pick the column with this component
      //
      switch(mi) {
        case 0: return new Vec3(u[0], u[1], u[2]);

        case 1:
        case 3: return new Vec3(u[1], u[3], u[4]);

        default: return new Vec3(u[2], u[4], u[5]);
      }
    }

    private static Vec3 GetMultiplicity2Evector(Sym3x3 matrix, float evalue) {
      //
      // compute M
      //
      Sym3x3 m = new Sym3x3 {
        [0] = matrix[0] - evalue,
        [1] = matrix[1],
        [2] = matrix[2],
        [3] = matrix[3] - evalue,
        [4] = matrix[4],
        [5] = matrix[5] - evalue
      };
      //
      // find the largest component
      //
      float mc = Math.Abs(m[0]);

      int mi = 0;

      for(int i = 1; i < 6; ++i) {
        float c = Math.Abs(m[i]);

        if (c > mc) {
          mc = c;
          mi = i;
        }
      }
      //
      // pick the first eigenvector based on this index
      //
      switch(mi) {
        case 0:
        case 1: return new Vec3(-m[1], m[0], 0.0f);

        case 2: return new Vec3(m[2], 0.0f, -m[0]);

        case 3:
        case 4: return new Vec3(0.0f, -m[4], m[3]);

        default: return new Vec3(0.0f, -m[5], m[4]);
      }
    }

    #endregion Private Methods

  }

}
