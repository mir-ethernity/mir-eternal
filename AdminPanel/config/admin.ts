export default ({ env }) => ({
  auth: {
    secret: env('ADMIN_JWT_SECRET', '97516747ae571388a633226276bc5048'),
  },
});
