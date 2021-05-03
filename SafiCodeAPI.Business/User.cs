using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SafiCodeAPI.Modal.Modal;

namespace SafiCodeAPI.Business
{

   

    public interface IUserService
    {
        TblUsers Authenticate(string Emain, string password);
        Task<IEnumerable<TblUserType>> GetAll();
        TblUsers GetById(int id);
        TblUsers Create(TblUsers user, string password);
        void Update(TblUsers user, string password = null);
        void Delete(int id);

    }


    public class UserService : IUserService
    {
        private SafiCodeContext _context;

        public UserService(SafiCodeContext context)
        {
            _context = context;
        }

        
        public async Task<IEnumerable<TblUserType>> GetAll()
        {
            return await _context.TblUserType.ToListAsync();
        }

        public TblUsers Authenticate(string Email, string password)
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(password))
                return null;


          
            var user = _context.TblUsers.SingleOrDefault(x => x.EmailId == Email);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct

            if (password == Security.AES256Decrypt(user.Password))
            {
                return user;
            }
            else
            {
                return null;
            }
            
        }

     
        public TblUsers Create(TblUsers user, string password)
        {
           
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_context.TblUsers.Any(x => x.EmailId == user.EmailId))
                throw new AppException("Email "+ user.EmailId + " is already taken");



            user.Password = Security.AES256Encrypt(password);
            user.UserTypeId=2;
            user.CreatedBy = 1;
            user.CreatedDate = DateTime.Now;
            user.IsActive = true;
            user.IsDeleted = false;

            _context.TblUsers.Add(user);
            _context.SaveChanges();

            return user;
        }

        public void Update(TblUsers userParam, string password = null)
        {
            //var user = _context.Users.Find(userParam.Id);

            //if (user == null)
            //    throw new AppException("User not found");

            //// update username if it has changed
            //if (!string.IsNullOrWhiteSpace(userParam.Username) && userParam.Username != user.Username)
            //{
            //    // throw error if the new username is already taken
            //    if (_context.Users.Any(x => x.Username == userParam.Username))
            //        throw new AppException("Username " + userParam.Username + " is already taken");

            //    user.Username = userParam.Username;
            //}

            //// update user properties if provided
            //if (!string.IsNullOrWhiteSpace(userParam.FirstName))
            //    user.FirstName = userParam.FirstName;

            //if (!string.IsNullOrWhiteSpace(userParam.LastName))
            //    user.LastName = userParam.LastName;

            //// update password if provided
            //if (!string.IsNullOrWhiteSpace(password))
            //{
            //    byte[] passwordHash, passwordSalt;
            //    CreatePasswordHash(password, out passwordHash, out passwordSalt);

            //    user.PasswordHash = passwordHash;
            //    user.PasswordSalt = passwordSalt;
            //}

            //_context.Users.Update(user);
            //_context.SaveChanges();
        }

        public TblUsers GetById(int id)
        {
            return _context.TblUsers.Find(id);
        }

        public void Delete(int id)
        {
            var user = _context.TblUsers.Find(id);
            if (user != null)
            {
                _context.TblUsers.Remove(user);
                _context.SaveChanges();
            }
        }


        //public byte[] ToByteArray(string str)
        //{
        //    return Encoding.Default.GetBytes(str); //System.Text.Encoding.ASCII.GetBytes(str);
        //}



        //private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        //{
        //    if (password == null) throw new ArgumentNullException("password");
        //    if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
        //    if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
        //    if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

        //    using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
        //    {
        //        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //        for (int i = 0; i < computedHash.Length; i++)
        //        {
        //            if (computedHash[i] != storedHash[i]) return false;
        //        }
        //    }

        //    return true;
        //}


        //private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        //{
        //    if (password == null) throw new ArgumentNullException("password");
        //    if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

        //    using (var hmac = new System.Security.Cryptography.HMACSHA512())
        //    {
        //        passwordSalt = hmac.Key;
        //        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //    }
        //}


        //private static bool VerifyPasswordHashstr(string password, byte[] storedHash, byte[] storedSalt)
        //{
        //    if (password == null) throw new ArgumentNullException("password");
        //    if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
        //    if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
        //    if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

        //    using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
        //    {
        //        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //        for (int i = 0; i < computedHash.Length; i++)
        //        {
        //            if (computedHash[i] != storedHash[i]) return false;
        //        }
        //    }

        //    return true;
        //}


        //private static void CreatePasswordHashstr(string password, out string passwordHash, out string passwordSalt)
        //{
        //    if (password == null) throw new ArgumentNullException("password");
        //    if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

        //    using (var hmac = new System.Security.Cryptography.HMACSHA512())
        //    {
        //        passwordSalt = hmac.Key.ToString();
        //        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)).ToString();
        //    }
        //}





    }



}