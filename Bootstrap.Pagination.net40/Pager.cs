using System;

namespace Bootstrap.Pagination
{
    /// <summary>
    ///     ��ӦBootstrap pager
    /// </summary>
    public class Pager
    {
        /// <summary>
        ///     ������������ǰҳ��ÿҳ����������Pager����
        /// </summary>
        /// <param name="totalItems">������</param>
        /// <param name="page">��ǰҳ</param>
        /// <param name="itemsPerPage">ÿҳ������</param>
        public Pager(int totalItems, int page, int itemsPerPage = 10)
        {
            Page = page;
            ItemsPerPage = itemsPerPage;
            TotalPages = (totalItems - 1) / itemsPerPage + 1;
        }

        /// <summary>
        ///     ÿҳ������
        /// </summary>
        public int ItemsPerPage { get; private set; }

        /// <summary>
        ///     ��ҳ��
        /// </summary>
        public int TotalPages { get; private set; }

        /// <summary>
        ///     ��ǰҳ,��1��ʼ
        /// </summary>
        public int Page { get; private set; }

        /// <summary>
        ///     �Ƿ��ǵ�1ҳ
        /// </summary>
        /// <returns></returns>
        public bool IsFirstPage
        {
            get
            {
                return Page == 1;
            }
        }
        /// <summary>
        ///     �Ƿ������1ҳ
        /// </summary>
        /// <returns></returns>
        public bool IsLastPage
        {
            get
            {
                return Page == TotalPages;
            }
        }
        /// <summary>
        ///     ��ǰҳ�У��ɴ�0��ʼ������������Ӧ��Skip��Щ��Ŀ������
        /// </summary>
        /// <returns></returns>
        [Obsolete]
        public int Skipped
        {
            get
            {
                return ItemsPerPage * (Page - 1);
            }
        }

        /// <summary>
        ///     ��ǰҳ�У��ɴ�0��ʼ������������Ӧ��Skip��Щ��Ŀ������
        /// </summary>
        /// <returns></returns>
        public static int GetSkipped(int page, int itemsPerPage = 10)
        {
            return (page - 1) * itemsPerPage;
        }
    }
}