using HCMUS.src.Entities.Auth;
using HCMUS.src.Modules.Auth.dto;
using HCMUS.src.Modules.Database;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static HCMUS.src.Modules.Auth.AuthModule;
using static HCMUS.src.Modules.Auth.dto.register_request;

namespace HCMUS.src.Modules.Auth
{
   
        public class AuthService : IAuthService
        {

            private readonly IMongoRepository<Users, ObjectId> _repository;

            public AuthService(IMongoRepository<Users, ObjectId> repository)
            {
                _repository = repository;
            }

            public async Task<string> Authencate(LoginRequest request)
            {
                // not fix warming await
                //var user = _repository.GetAll().First();
                //return "ok"+user.Code;
                var user = _repository.GetAll().FirstOrDefault(x => x.Email == request.Email);
                //return null if user not found

                if (user == null) return null;
                byte[] secretSalt = Encoding.ASCII.GetBytes("minh123456");
                var isTruePass = VerifyPasswordHash(request.Password, user.Password, secretSalt);
                if (isTruePass)
                {
                    var token = generateJwtToken(user);
                    return token;
                }
                return null;


            }

            public string generateJwtToken(Users user)
            {
                //generate token that us valid 7 day
                var tokenHandler = new JwtSecurityTokenHandler();

                var key = Encoding.ASCII.GetBytes("minh123456");
                var tokenDescription = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescription);
                return tokenHandler.WriteToken(token);

            }

            public async Task<bool> Register(RegisterRequest request)
            {
                try
                {

                    //byte[] passwordHash = null;
                    //byte[] secretSalt = Encoding.ASCII.GetBytes("minh123456");
                    //CreatePasswordHash(request.Password, out passwordHash, secretSalt);

                    //User userNew = new User()
                    //{
                    //    Email = request.Email,
                    //    FirstName = request.FirstName,
                    //    LastName = request.LastName,
                    //    IsConnected = true,
                    //    Password = Encoding.ASCII.GetString(passwordHash)
                    //};
                    //await AddUser(userNew);
                    return true;
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.ToString());
                }
            }

            private static void CreatePasswordHash(string password, out byte[] passwordHash, byte[] secretSalt)
            {
                if (password == null) throw new ArgumentNullException("password not null");
                if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

                using (var hmac = new System.Security.Cryptography.HMACSHA512(secretSalt))
                {
                    passwordHash = hmac.ComputeHash(System.Text.Encoding.ASCII.GetBytes(password));
                }

            }

            private static bool VerifyPasswordHash(string password, string storedHash, byte[] secretSalt)
            {
                //storeHash get from database
                if (password == null) throw new ArgumentNullException("password");
                if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
                //  if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
                //if (secretSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

                using (var hmac = new System.Security.Cryptography.HMACSHA512(secretSalt))
                {
                    var computedHash = hmac.ComputeHash(System.Text.Encoding.ASCII.GetBytes(password));

                    //for (int i = 0; i < computedHash.Length; i++)
                    //{
                    //    var computedHashd = computedHash[i];
                    //    var storedHashsss = storedHash[i];
                    //    if (computedHash[i] != storedHash[i])
                    //        return false;
                    //}

                    string computedHashString = Encoding.ASCII.GetString(computedHash);
                    if (computedHashString != storedHash) return false;

                }
                return true;
            }

        public async Task<IEnumerable<Users>> GetAllUsers()
        {
            try
            {
                return await _repository.GetAllListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        }
}
