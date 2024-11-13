using DAL;
using DAL.models;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class User_BL
    {
        private readonly User_DAL userDAL;
        public User_BL(User_DAL dal)
        {
            userDAL = dal;
        }

        //conversion functions
        private User_DTO ConvertToDTO(User user)
        {
            return new User_DTO()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                UserPass = user.UserPass,
                UserEmail = user.UserEmail,
                IsAdmin = user.IsAdmin,
                NumOfPlaylists = user.Playlists == null ? 0 : user.Playlists.Count()
            };
        }

        private List<User_DTO> ConvertToDTO(List<User>users)
        {
            List<User_DTO>lst = new List<User_DTO>();
            foreach (User u in users)
                lst.Add(ConvertToDTO(u));
            return lst;
        }

        private User ConvertFromDTO(User_DTO user)
        {
            return new User()
            {
                UserId = user.UserId,
                UserName = user.UserName,
                UserPass = user.UserPass,
                UserEmail = user.UserEmail,
                IsAdmin = user.IsAdmin
            };
        }

        private List<User> ConvertFromDTO(List<User_DTO>users)
        {
            List<User>lst = new List<User>();
            foreach (User_DTO u in users)
                lst.Add(ConvertFromDTO(u));
            return lst;
        }

        //get all
        public async Task<List<User_DTO>> SelectAllAsync()
        {
            return ConvertToDTO(await userDAL.SelectAllAsync());
        }

        //get by user id
        public async Task<User_DTO?> SelectByIdAsync(int userId)
        {
            User u = await userDAL.SelectByIdAsync(userId);
            return u == null ? null : ConvertToDTO(u);
        }

        //get by password
        public async Task<User_DTO?> SelectByPasswordAsync(string pass)
        {
            User u = await userDAL.SelectByPasswordAsync(pass);
            return u == null ? null : ConvertToDTO(u);
        }

        //get by email
        public async Task<User_DTO?> SelectByEmailAsync(string email)
        {
            User u = await userDAL.SelectByEmailAsync(email);
            return u == null ? null : ConvertToDTO(u);
        }

        //get by name and password
        public async Task<User_DTO?> SelectByNameAndPasswordAsync(string name, string pass)
        {
            User u = await userDAL.SelectByNameAndPasswordAsync(name, pass);
            return u == null ? null : ConvertToDTO(u);
        }

        //add user
        public async Task<int> AddUserAsync(User_DTO user)
        {
            if (user == null) return -1;
            return await userDAL.AddUserAsync(ConvertFromDTO(user));
        }

        //update user
        public async Task<int> UpdateAsync(User_DTO user)
        {
            if (user == null) return -1;
            return await userDAL.UpdateAsync(ConvertFromDTO(user));
        }

        //delete by user id
        public async Task<int> DeleteAsync(int userId)
        {
            return await userDAL.DeleteAsync(userId);
        }


    }
}
