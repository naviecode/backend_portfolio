namespace Portfolio.Extension
{
    public static class HttpContextExtension 
    {
        public static int GetUserId(this HttpContext httpContext)
        {
            return httpContext.Items["User"] as int? ?? throw new Exception("User not found");
        }
    }
}
