﻿using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace Ch11_Cryptography
{
    public static class Protector
    {
        //salt size must be at least 8 bytes , we will use 16 bytes
        private static readonly byte[] salt = Encoding.Unicode.GetBytes("7BANANAS");

        //iterations must be at least 1000, we will use 2000
        private static readonly int iterations = 2000;

        public static Dictionary<string, User> Users = new Dictionary<string, User>();

        public static string Encrypt(string plainText, string password)
        {
            byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);
            var aes = Aes.Create();
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            aes.Key = pbkdf2.GetBytes(32); //set a 256-bit key
            aes.IV = pbkdf2.GetBytes(16); //set a 128-bit IV
            var ms = new MemoryStream();

            using (var cs = new CryptoStream(ms, aes.CreateEncryptor(),CryptoStreamMode.Write))
            {
                cs.Write(plainBytes, 0, plainBytes.Length);
            }
            return Convert.ToBase64String(ms.ToArray());
        }

        public static string Decrypt(string cryptoText, string password)
        {
            byte[] cryptoBytes = Convert.FromBase64String(cryptoText);
            var aes = Aes.Create();
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            aes.Key = pbkdf2.GetBytes(32);
            aes.IV = pbkdf2.GetBytes(16);
            var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cs.Write(cryptoBytes, 0, cryptoBytes.Length);
            }
            return Encoding.Unicode.GetString(ms.ToArray());
        }

        public static User Register(string username, string password)
        {
            //generate a random salt
            var rng = RandomNumberGenerator.Create();
            var saltBytes = new byte[16];
            rng.GetBytes(saltBytes);
            var saltText = Convert.ToBase64String(saltBytes);

            //generate the salted and hashed password
            var sha2 = SHA256.Create();
            var saltedPassword = password + saltText;
            var saltedHashedPassword = Convert.ToBase64String(sha2.ComputeHash(Encoding.Unicode.GetBytes(saltedPassword)));

            var user = new User
            {
                Name = username,
                Salt = saltText,
                SaltedHashedPassword = saltedHashedPassword
            };
            Users.Add(user.Name, user);
            return user;
        }

        public static bool CheckPassword(string username, string password)
        {
            if (!Users.ContainsKey(username))
            {
                return false;
            }
            var user = Users[username];

            var sha = SHA256.Create();
            var saltedPassword = password + user.Salt;
            var saltedHashedPassword = Convert.ToBase64String(sha.ComputeHash(Encoding.Unicode.GetBytes(saltedPassword)));

            return (saltedHashedPassword == user.SaltedHashedPassword);
        }
    }

    public class User
    {
        public string Name { get; set; }
        public string Salt { get; set; }
        public string SaltedHashedPassword { get; set; }
    }
}
