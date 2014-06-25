namespace Bootstrap.Pagination
{
    /// <summary>
    ///     ��ӦBootstrap pager
    /// </summary>
    public class Pager
    {
        private readonly int _pageCount;
        /// <summary>
        ///     ������������ǰҳ��ÿҳ����������Pager����
        /// </summary>
        /// <param name="totalItems"></param>
        /// <param name="page"></param>
        /// <param name="itemsPerPage"></param>
        public Pager(int totalItems, int page, int itemsPerPage)
        {
            Page = page;
            _pageCount = (totalItems - 1) / itemsPerPage + 1;
        }
        /// <summary>
        ///     ��ǰҳ,��1��ʼ
        /// </summary>
        public int Page { get; private set; }
        /// <summary>
        ///     �Ƿ��ǵ�1ҳ
        /// </summary>
        /// <returns></returns>
        public bool IsFirstPage()
        {
            return Page == 1;
        }
        /// <summary>
        ///     �Ƿ������1ҳ
        /// </summary>
        /// <returns></returns>
        public bool IsLastPage()
        {
            return Page == _pageCount;
        }
    }
}