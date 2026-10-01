using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Domain.Entities
{
    public class User : BaseEntity, IFollowable, INotifiable
    {

        public string _firstName { get; private set; }
        public string _lastName { get; private set; }
        public string _email { get; private set; }
        public string _password { get; private set; }
        public string _gender { get; private set; }
        public string _phone { get; private set; }

        private List<Guid> _followers = new List<Guid>();
        private List<Guid> _notifications = new List<Guid>();

        public User(string firstName, string lastName, string email, string password, string gender, string phone) : base(Guid.NewGuid())
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _password = password;
            _gender = gender;
            _phone = phone;
        }



        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public void Update(
            string firstName,
            string lastName,
            string password,
            string gender,
            string phone)
        {
            _firstName = firstName;
            _lastName = lastName;
            _password = password;
            _gender = gender;
            _phone = phone;
        }
        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, First Name: {FirstName}, Last Name: {LastName}, Email: {Email}, Password: {Password}, Gender: {Gender}, Phone: {Phone}, Followers: {_followers.Count}, Notifications: {_notifications.Count}";
        }

        public void Follow(Guid userId)
        {
            if (!_followers.Contains(userId))
            {
                _followers.Add(userId);
            }
        }

        public void Unfollow(Guid userId)
        {
            _followers.Remove(userId);
        }

        public void AddNotification(Guid notificationId)
        {
            if (!_notifications.Contains(notificationId))
            {
                _notifications.Add(notificationId);
            }
        }
    }
}
