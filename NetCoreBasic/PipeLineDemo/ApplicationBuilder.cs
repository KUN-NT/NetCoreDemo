using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipeLineDemo
{
    public class ApplicationBuilder
    {
        /// <summary>
        /// 中间件列表
        /// </summary>
        private static readonly IList<Func<RequestDelegate, RequestDelegate>> _components =
            new List<Func<RequestDelegate, RequestDelegate>>();

        /// <summary>
        /// 扩展Use
        /// </summary>
        /// <param name="middleware">中间件</param>
        /// <returns></returns>
        public ApplicationBuilder Use(Func<HttpContext,Func<Task>,Task> middleware)
        {
            return Use(next =>
            {
                return context =>
                {
                    Task SimpleNext() => next(context);
                    return middleware(context, SimpleNext);
                };
            });
        }

        /// <summary>
        /// 原始Use
        /// </summary>
        /// <param name="middleware">中间件</param>
        /// <returns></returns>
        public ApplicationBuilder Use(Func<RequestDelegate,RequestDelegate> middleware)
        {
            //添加中间件
            _components.Add(middleware);
            return this;
        }

        /// <summary>
        /// 生成管道
        /// </summary>
        /// <returns></returns>
        public RequestDelegate Build()
        {
            //设置一个默认中间件
            RequestDelegate app = context =>
             {
                 Console.WriteLine("默认中间件");
                 return Task.CompletedTask;
             };

            //把独立的中间件委托串起来 然后返回反转后最后一个中间件(即第一个注册的中间件)
            //至此管道才真正建立起来 每一个中间件首位相连
            //主机创建以后运行
            foreach(var component in _components.Reverse())
            {
                app = component(app);
            }

            return app;
        }
    }
}
