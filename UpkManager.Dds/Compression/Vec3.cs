using System;


namespace UpkManager.Dds.Compression {

  internal sealed class Vec3 {

    #region Private Fields

    private float x;
    private float y;
    private float z;

    #endregion Private Fields

    #region Constructors

    public Vec3(float S) {
      x = S;
      y = S;
      z = S;
    }

    public Vec3(float X, float Y, float Z) {
      x = X;
      y = Y;
      z = Z;
    }

    public Vec3(Vec3 copy) {
      x = copy.x;
      y = copy.y;
      z = copy.z;
    }

    #endregion Constructors

    #region Properties

    public float X => x;

    public float Y => y;

    public float Z => z;

    #endregion Properties

    #region Operator Overrides

    public static Vec3 operator+(Vec3 left, Vec3 right) {
      Vec3 copy = new Vec3(left);

      return add(copy, right);
    }

    public static Vec3 operator-(Vec3 left, Vec3 right) {
      Vec3 copy = new Vec3(left);

      return subtract(copy, right);
    }

    public static Vec3 operator*(Vec3 left, Vec3 right) {
      Vec3 copy = new Vec3(left);

      return multiply(copy, right);
    }

    public static Vec3 operator*(float left, Vec3 right) {
      Vec3 copy = new Vec3(right);

      return multiply(copy, left);
    }

    public static Vec3 operator/(Vec3 left, float right) {
      Vec3 copy = new Vec3(left);

      return divide(copy, right);
    }

    #endregion Operator Overrides

    #region Public Methods

    public static float Dot(Vec3 left, Vec3 right) {
      return left.x * right.x + left.y * right.y + left.z * right.z;
    }

    public static Vec3 Min(Vec3 left, Vec3 right) {
      return new Vec3(Math.Min(left.x, right.x), Math.Min(left.y, right.y), Math.Min(left.z, right.z));
    }

    public static Vec3 Max(Vec3 left, Vec3 right) {
      return new Vec3(Math.Max(left.x, right.x), Math.Max(left.y, right.y), Math.Max(left.z, right.z));
    }

    public static Vec3 Truncate(Vec3 v) {
      return new Vec3((float)(v.x > 0.0f ? Math.Floor(v.x ) : Math.Ceiling(v.x)), (float)(v.y > 0.0f ? Math.Floor(v.y) : Math.Ceiling(v.y)), (float)(v.z > 0.0f ? Math.Floor(v.z ) : Math.Ceiling(v.z)));
    }

    public static float LengthSquared(Vec3 v) {
      return Dot(v, v);
    }

    #endregion Public Methods

    #region Private Methods

    private static Vec3 add(Vec3 left, Vec3 right) {
      left.x += right.x;
      left.y += right.y;
      left.z += right.z;

      return left;
    }

    private static Vec3 subtract(Vec3 left, Vec3 right) {
      left.x -= right.x;
      left.y -= right.y;
      left.z -= right.z;

      return left;
    }

    private static Vec3 multiply(Vec3 left, Vec3 right) {
      left.x *= right.x;
      left.y *= right.y;
      left.z *= right.z;

      return left;
    }

    private static Vec3 multiply(Vec3 left, float right) {
      left.x *= right;
      left.y *= right;
      left.z *= right;

      return left;
    }

    private static Vec3 divide(Vec3 left, float right) {
      return multiply(left, 1.0f / right);
    }

    #endregion Private Methods

  }

}
