namespace WEBAPI.WEBUI.BL.Service
{
    static class Utilities
    {
        public static bool CheckIdForNegativ(int id)
        {
            return id >= 0;
        }
        public static bool CheckEmailAddress(string email)
        {
            var emailChecker = new System.ComponentModel.DataAnnotations.EmailAddressAttribute();
            return emailChecker.IsValid(email);
        }
    }
}


