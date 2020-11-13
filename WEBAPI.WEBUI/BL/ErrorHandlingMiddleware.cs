using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WEBAPI.WEBUI.BL.Exceptions;
using Newtonsoft.Json;
using System;
using System.Data.Common;
using System.Net;
using System.Threading.Tasks;

namespace WEBAPI.WEBUI.BL
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;

            if (ex is WrongReportOutputTypeException) code = HttpStatusCode.BadRequest;
            else if (ex is WrongReportTypeException) code = HttpStatusCode.BadRequest;
            else if (ex is NegativeIDException) code = HttpStatusCode.BadRequest;
            else if (ex is WrongEmailException) code = HttpStatusCode.BadRequest;

            else if (ex is DbUpdateException)
                code = HttpStatusCode.InternalServerError;

            else if (ex is DbException)
                code = HttpStatusCode.InternalServerError;

            else if (ex is Exception)
                code = HttpStatusCode.InternalServerError;


            var result = JsonConvert.SerializeObject(new { error = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
