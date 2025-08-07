namespace PubsPractice.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        /// <summary>
        /// ���A���~�X
        /// </summary>
        public string ErrorNum { get; set; }
        /// <summary>
        /// ���~�T��
        /// </summary>
        public string ErrorMsg { get; set; }

        public ErrorViewModel()
        {

        }
        /// <summary>
        /// option �w�]���A  1=���\ 2=���� 3=�d�L��� 4=�t�ΥX�{�w���~���p
        /// </summary>
        /// <param name="option"></param>
        public ErrorViewModel(string option)
        {
            if(option == "1")
            {
                ErrorNum = "200";
                ErrorMsg = "���\";
            }
            else if(option == "2")
            {
                ErrorNum = "400";
                ErrorMsg = "����";
            }
            else if (option == "3")
            {
                ErrorNum = "201";
                ErrorMsg = "�d�L�ӵ����";
            }
            else 
            {
                ErrorNum = "401";
                ErrorMsg = "�t�ΥX��";
            }
        }
        /// <summary>
        /// option �w�]���A  1=���\ 2=���� 3=�d�L��� 4=�t�ΥX�{�w���~���p
        /// </summary>
        /// <param name="option"></param>
        public void SetMsg(string option, string? errorMsg = "")
        {
            if (option == "1")
            {
                ErrorNum = "200";
                ErrorMsg = "���\";
            }
            else if (option == "2")
            {
                ErrorNum = "400";
                ErrorMsg = "����";
            }
            else if (option == "3")
            {
                ErrorNum = "201";
                ErrorMsg = "�d�L�ӵ����";
            }
            else
            {
                ErrorNum = "401";
                ErrorMsg = "�t�ΥX��";
            }
            if(string.IsNullOrWhiteSpace(errorMsg))
            {
                ErrorMsg = errorMsg;
            }
        }
    }
}