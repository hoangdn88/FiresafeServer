using Common.Entities.DataTransferObjects.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.JwtHelper
{
    public class PagingMiddleware : Attribute, IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var totalItem = context.HttpContext.Request.Headers["TotalItem"].ToString();
            var paging = context.HttpContext.Request.Headers["Paging"].ToString();
            var curentPage = context.HttpContext.Request.Headers["CurrentPage"].ToString();
            var pageSize = context.HttpContext.Request.Headers["PageSize"].ToString();
            // var pagingParameter = new PageParametersDto();
            if (!string.IsNullOrEmpty(paging))
            {
                var option = new PageParametersDto();
                option.Paging = bool.Parse(paging);
                option.CurrentPage = int.Parse(!string.IsNullOrEmpty(curentPage) ? curentPage : "1");
                option.PageSize = int.Parse(!string.IsNullOrEmpty(pageSize) ? pageSize : "20");
                if (option.Paging)
                {
                    var pager = new PageParametersDto(int.Parse(totalItem));
                    pager.CurrentPage = option.CurrentPage;
                    pager.PageSize = option.PageSize;
                    pager = new PageParametersDto(int.Parse(totalItem), pager.CurrentPage, pager.PageSize);
                    var metadata = new
                    {
                        pager.TotalItems,
                        pager.CurrentPage,
                        pager.PageSize,
                        pager.TotalPages,
                        pager.StartIndex,
                        pager.EndIndex,
                        pager.Pages
                    };

                    context.HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                }
            }
            await next();

        }
    }
}
