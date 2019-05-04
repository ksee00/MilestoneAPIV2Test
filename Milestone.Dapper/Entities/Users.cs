using System;

namespace Milestone.Dapper.Entities
{
    public class Users : BaseModel
    {
        /// <summary>
        /// User ID
        /// </summary>
        public string uid { get; set; }

        /// <summary>
        /// User Name
        /// </summary>
        public string userName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Driver
        /// </summary>
        public string Driver { get; set; }

        /// </summary>
        /// <summary>
        /// 性别（0女，1男）
        /// </summary>
        //public int Gender { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        public string role { get; set; }

        /// <summary>
        /// Role Type
        /// </summary>
        public string roleType { get; set; }

        /// <summary>
        /// Shift Flag
        /// </summary>
        public string shift_flag { get; set; }
    }
}
