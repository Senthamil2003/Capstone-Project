﻿using CapstoneQuizzCreationApp.Context;
using CapstoneQuizzCreationApp.CustomException;
using CapstoneQuizzCreationApp.Interfaces;
using CapstoneQuizzCreationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CapstoneQuizzCreationApp.Repositories.GeneralRepository
{
    public class UserCredentialRepository : IRepository<string, UserCredential>
    {
        private readonly QuizzContext _context;

        public UserCredentialRepository(QuizzContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<UserCredential> Add(UserCredential item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "UserCredential cannot be null");

            try
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {

                throw new RepositoryException("Error occurred while adding the UserCredential. " + ex);
            }
        }

        public async Task<UserCredential> Delete(string key)
        {
            try
            {
                var userCredential = await Get(key);
                _context.Remove(userCredential);
                await _context.SaveChangesAsync();
                return userCredential;
            }

            catch (Exception ex)
            {

                throw new RepositoryException("Error occurred while deleting the UserCredential. " + ex);
            }
        }

        public async Task<UserCredential> Get(string key)
        {
            try
            {
                return await _context.UserCredentials.SingleOrDefaultAsync(u => u.Email == key)
                    ?? throw new UserCredentialNotFoundException($"No user found with given id {key}");
            }
            catch (UserCredentialNotFoundException)
            {
                throw;
            }


            catch (Exception ex)
            {
                throw new RepositoryException("Error Occur while fetching data from UserCredential. " + ex);
            }
        }

        public async Task<IEnumerable<UserCredential>> Get()
        {
            try
            {
                return await _context.UserCredentials.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new RepositoryException("Error occurred while fetching the UserCredentials. " + ex);
            }
        }

        public async Task<UserCredential> Update(UserCredential item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item), "UserCredential cannot be null");

            try
            {
                var userCredential = await Get(item.Email);
                _context.Entry(userCredential).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();
                return userCredential;
            }
            catch (Exception ex)
            {
                throw new RepositoryException("Error occurred while updating the UserCredential. " + ex);
            }
        }
    }

}
