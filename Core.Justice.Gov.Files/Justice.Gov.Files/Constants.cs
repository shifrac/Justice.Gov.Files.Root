namespace Justice.Gov.Files
{
    public class Constants
    {
        public class EmailSetting
        {
            public const string ServerKeyName = "EmailSetting:SmtpClient:Server";
            public const string PortKeyName = "EmailSetting:SmtpClient:Post";
            public const string SubjectKeyName = "EmailSetting:Subject";
            public const string BodyKeyName = "EmailSetting:Body";
            public const string SenderKeyName = "EmailSetting:Sender";
            public const string PasswordKeyName = "EmailSetting:Password";
        }
        public class DBSetting
        {
            public const string JsonFilePathKeyName = "DBSetting:JsonFilePath";
        }
    }
}
