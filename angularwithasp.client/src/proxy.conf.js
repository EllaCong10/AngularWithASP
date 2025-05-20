const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT
  ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}`
  : env.ASPNETCORE_URLS
    ? env.ASPNETCORE_URLS.split(';')[0]
    : 'https://localhost:7232';

const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
      "/api", // 添加这一行来代理登录等 API 请求
    ],
    target,
    secure: false,
    changeOrigin: true, //建议加上，避免 host 校验问题
  }
];

module.exports = PROXY_CONFIG;
