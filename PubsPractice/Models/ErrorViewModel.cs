namespace PubsPractice.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        /// <summary>
        /// 狀態錯誤碼
        /// </summary>
        public string ErrorNum { get; set; }
        /// <summary>
        /// 錯誤訊息
        /// </summary>
        public string ErrorMsg { get; set; }

        public ErrorViewModel()
        {

        }
        /// <summary>
        /// option 預設狀態  1=成功 2=失敗 3=查無資料 4=系統出現預期外狀況
        /// </summary>
        /// <param name="option"></param>
        public ErrorViewModel(string option)
        {
            if(option == "1")
            {
                ErrorNum = "200";
                ErrorMsg = "成功";
            }
            else if(option == "2")
            {
                ErrorNum = "400";
                ErrorMsg = "失敗";
            }
            else if (option == "3")
            {
                ErrorNum = "201";
                ErrorMsg = "查無該筆資料";
            }
            else 
            {
                ErrorNum = "401";
                ErrorMsg = "系統出錯";
            }
        }
        /// <summary>
        /// option 預設狀態  1=成功 2=失敗 3=查無資料 4=系統出現預期外狀況
        /// </summary>
        /// <param name="option"></param>
        public void SetMsg(string option, string? errorMsg = "")
        {
            if (option == "1")
            {
                ErrorNum = "200";
                ErrorMsg = "成功";
            }
            else if (option == "2")
            {
                ErrorNum = "400";
                ErrorMsg = "失敗";
            }
            else if (option == "3")
            {
                ErrorNum = "201";
                ErrorMsg = "查無該筆資料";
            }
            else
            {
                ErrorNum = "401";
                ErrorMsg = "系統出錯";
            }
            if(string.IsNullOrWhiteSpace(errorMsg))
            {
                ErrorMsg = errorMsg;
            }
        }
    }
}