
using System;
using System.Collections.Generic;
using System.Text;

namespace DapperTemplate.Model
{
    [Serializable]
    public partial class User
    {
        #region Attributes
        /// <summary>
        /// UserId(PK)
        /// IsNullable=False
        ///</summary>
        private Int32 userId;
        public Int32 UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        /// <summary>
        /// Username
        /// IsNullable=False
        ///</summary>
        private String username;
        public String Username
        {
            get { return username; }
            set { username = value; }
        }
        /// <summary>
        /// PasswordHash
        /// IsNullable=True
        ///</summary>
        private String passwordHash;
        public String PasswordHash
        {
            get { return passwordHash; }
            set { passwordHash = value; }
        }
        /// <summary>
        /// Email
        /// IsNullable=True
        ///</summary>
        private String email;
        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        /// <summary>
        /// PhoneNumber
        /// IsNullable=True
        ///</summary>
        private String phoneNumber;
        public String PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        /// <summary>
        /// IsFirstTimeLogin
        /// IsNullable=False
        ///</summary>
        private Boolean? isFirstTimeLogin;
        public Boolean? IsFirstTimeLogin
        {
            get { return isFirstTimeLogin; }
            set { isFirstTimeLogin = value; }
        }
        /// <summary>
        /// AccessFailedCount
        /// IsNullable=False
        ///</summary>
        private Int32? accessFailedCount;
        public Int32? AccessFailedCount
        {
            get { return accessFailedCount; }
            set { accessFailedCount = value; }
        }
        /// <summary>
        /// CreationDate
        /// IsNullable=False
        ///</summary>
        private DateTime? creationDate;
        public DateTime? CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }
        /// <summary>
        /// IsActive
        /// IsNullable=False
        ///</summary>
        private Boolean? isActive;
        public Boolean? IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
        /// <summary>
        /// LastTimestamp
        /// IsNullable=True
        ///</summary>
        private Byte[] lastTimestamp;
        public Byte[] LastTimestamp
        {
            get { return lastTimestamp; }
            set { lastTimestamp = value; }
        }
        #endregion
    }
}


