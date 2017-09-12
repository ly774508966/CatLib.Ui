namespace CatLib.Ui
{
    public interface IBrowser
    {
        /// <summary>
        /// 当前页面
        /// 可以返回空
        /// </summary>
        IPage CurrentPage { get; }

        /// <summary>
        /// 进入页面，返回页面实例
        /// </summary>
        /// <param name="pageName"></param>
        /// <returns></returns>
        IPage EnterPage(string pageName);

        bool CanEnterPage(string pageName);
    }
}