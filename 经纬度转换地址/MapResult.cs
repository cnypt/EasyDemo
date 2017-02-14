namespace 经纬度转换地址
{
    internal class MapResult
    {
        private int status = -1;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        private Result result = new Result();

        public Result Result
        {
            get { return result; }
            set { result = value; }
        }
    }
}