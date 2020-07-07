using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDemo.Middleware
{
    /// <summary>
    /// 自定义中间件
    /// </summary>
    public class TestMiddleware
    {
        // 注册中间件时调用
        private readonly RequestDelegate _next;
        public TestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        /// 中间件业务代码  
        /// 请求到达时调用
        /// </summary>
        /// <param name="httpContext">http上下文</param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            //Http请求部分处理代码
            await httpContext.Response.WriteAsync("Test Request Middleware\r\n");

            await _next(httpContext);

            //Http响应部分处理代码
            await httpContext.Response.WriteAsync("Test Response Middleware\r\n");
        }
    }
}
