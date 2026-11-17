
namespace TwitterClone.Domain.Entities
{
    public class User : BaseEntity, IFollowable, INotifiable
    {
        // Private backing fields
        private string _firstName = string.Empty;
        private string _lastName = string.Empty;
        private string _email = string.Empty;
        private string _passwordHash = string.Empty;
        private string _gender = string.Empty;
        private string _phone = string.Empty;

        private List<Guid> _followers = new();
        private List<Guid> _notifications = new();

        // Properties
        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string PasswordHash
        {
            get => _passwordHash;
            set => _passwordHash = value;
        }

        public string Gender
        {
            get => _gender;
            set => _gender = value;
        }

        public string Phone
        {
            get => _phone;
            set => _phone = value;
        }

        // EF Core constructor
        private User() : base(Guid.Empty)
        {
        }

        // Application constructor
        public User(
            string firstName,
            string lastName,
            string email,
            string password,
            string gender,
            string phone
        ) : base(Guid.NewGuid())
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _passwordHash = password;
            _gender = gender;
            _phone = phone;
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
            _passwordHash = password;
            _gender = gender;
            _phone = phone;
        }

        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();

            return $"{baseRecord}, First Name: {FirstName}, Last Name: {LastName}, Email: {Email}, Gender: {Gender}, Phone: {Phone}, Followers: {_followers.Count}, Notifications: {_notifications.Count}";
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
