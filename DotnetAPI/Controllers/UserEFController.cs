using DotnetApi.Data;
using DotnetApi.Dtos;
using DotnetApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserEFController : ControllerBase
{
    DataContextEF _entityFramework;
    public UserEFController(IConfiguration config)
    {
        _entityFramework = new DataContextEF(config);
    }

    [HttpGet("GetUsers")]
    public IEnumerable<User> GetUsers()
    {
        IEnumerable<User> users = _entityFramework.Users.ToList<User>();
        return users;
    }
    [HttpGet("GetSingleUser/{userId}")]
    public User GetSingleUser(int userId)
    {
        User? user = _entityFramework.Users
            .Where(u => u.UserId == userId)
            .FirstOrDefault<User>();
        if (user != null)
        {
            return user;
        }
        throw new Exception("Failed to Get User");
    }

    [HttpPut("EditUser")]
    public IActionResult EditUser(User user)
    {
        User? userDb = _entityFramework.Users
             .Where(u => u.UserId == user.UserId)
             .FirstOrDefault<User>();
        if (userDb != null)
        {
            userDb.Active = user.Active;
            userDb.FirstName = user.FirstName;
            userDb.LastName = user.LastName;
            userDb.Email = user.Email;
            userDb.Gender = user.Gender;
            if (_entityFramework.SaveChanges() > 0)
            {
                return Ok();
            }

            throw new Exception("Failed to Update User");
        }
        throw new Exception("Failed to Get User");
    }

    [HttpPost("AddUser")]
    public IActionResult AddUser(UserDto user)
    {
        User userDb = new User();

        userDb.Active = user.Active;
        userDb.FirstName = user.FirstName;
        userDb.LastName = user.LastName;
        userDb.Email = user.Email;
        userDb.Gender = user.Gender;
        _entityFramework.Users.Add(userDb);

        if (_entityFramework.SaveChanges() > 0)
        {
            return Ok();
        }

        throw new Exception("Failed to Add User");
    }

    [HttpDelete("DeleteUser/{userId}")]
    public IActionResult DeleteUser(int userId)
    {
        User? userDb = _entityFramework.Users
              .Where(u => u.UserId == userId)
              .FirstOrDefault<User>();

        if (userDb != null)
        {
            _entityFramework.Users.Remove(userDb);
            if (_entityFramework.SaveChanges() > 0)
            {
                return Ok();
            }

            throw new Exception("Failed to Delete User");
        }
        throw new Exception("Failed to Get User");
    }

    //////////////////////////////////////////
    /// Salary
    //////////////////////////////////////////

    [HttpGet("UserSalary/{userId}")]
    public IEnumerable<UserSalary> GetUserSalary(int userId)
    {
        return _entityFramework.UserSalary
            .Where(u => u.UserId == userId)
            .ToList();
    }

    [HttpPost("UserSalary")]
    public IActionResult PostUserSalaryEF(UserSalary userSalaryForInsert)
    {
        _entityFramework.UserSalary.Add(userSalaryForInsert);
        if (_entityFramework.SaveChanges() > 0)
        {
            return Ok(userSalaryForInsert);
        }

        throw new Exception("Failed to Add User Salary");
    }

    [HttpPut("UserSalary")]
    public IActionResult PutUserSalary(UserSalary userSalaryForUpdate)
    {
        UserSalary? userSalaryDb = _entityFramework.UserSalary
            .Where(u => u.UserId == userSalaryForUpdate.UserId)
            .FirstOrDefault<UserSalary>();

        if (userSalaryDb != null)
        {
            userSalaryDb.Salary = userSalaryForUpdate.Salary;
            if (_entityFramework.SaveChanges() > 0)
            {
                return Ok(userSalaryForUpdate);
            }

            throw new Exception("Failed to Update User Salary");
        }
        throw new Exception("Failed to Get User Salary");
    }

    [HttpDelete("UserSalary/{userId}")]
    public IActionResult DeleteUserSalary(int userId)
    {
        UserSalary? userSalaryDb = _entityFramework.UserSalary
            .Where(u => u.UserId == userId)
            .FirstOrDefault<UserSalary>();

        if (userSalaryDb != null)
        {
            _entityFramework.UserSalary.Remove(userSalaryDb);
            if (_entityFramework.SaveChanges() > 0)
            {
                return Ok();
            }

            throw new Exception("Failed to Delete User Salary");
        }
        throw new Exception("Failed to Get User Salary");
    }

    //////////////////////////////////////////
    /// User Job Info
    //////////////////////////////////////////

    [HttpGet("UserJobInfo/{userId}")]
    public IActionResult GetUserJobInfo(int userId)
    {
        UserJobInfo? userJobInfo = _entityFramework.UserJobInfo
            .Where(u => u.UserId == userId)
            .FirstOrDefault<UserJobInfo>();

        if (userJobInfo != null)
        {
            return Ok(userJobInfo);
        }
        throw new Exception("Failed to Get User JobInfo");
    }

    [HttpPost("UserJobInfo")]
    public IActionResult PostUserJobInfo(UserJobInfo userJobInfoForInsert)
    {
        UserJobInfo userJobInfoDb = new UserJobInfo();

        userJobInfoDb.UserId = userJobInfoForInsert.UserId;
        userJobInfoDb.Department = userJobInfoForInsert.Department;
        userJobInfoDb.JobTitle = userJobInfoForInsert.JobTitle;
        _entityFramework.UserJobInfo.Add(userJobInfoDb);

        if (_entityFramework.SaveChanges() > 0)
        {
            return Ok(userJobInfoForInsert);
        }

        throw new Exception("Failed to Add User JobInfo");
    }

    [HttpPut("UserJobInfo")]
    public IActionResult PutUserJobInfo(UserJobInfo userJobInfoForUpdate)
    {
        UserJobInfo? userJobInfoDb = _entityFramework.UserJobInfo
            .Where(u => u.UserId == userJobInfoForUpdate.UserId)
            .FirstOrDefault<UserJobInfo>();

        if (userJobInfoDb != null)
        {
            userJobInfoDb.Department = userJobInfoForUpdate.Department;
            userJobInfoDb.JobTitle = userJobInfoForUpdate.JobTitle;
            if (_entityFramework.SaveChanges() > 0)
            {
                return Ok(userJobInfoForUpdate);
            }

            throw new Exception("Failed to Update User JobInfo");
        }
        throw new Exception("Failed to Get User JobInfo");
    }

    [HttpDelete("UserJobInfo/{userId}")]
    public IActionResult DeleteUserJobInfo(int userId)
    {
        UserJobInfo? userJobInfoDb = _entityFramework.UserJobInfo
            .Where(u => u.UserId == userId)
            .FirstOrDefault<UserJobInfo>();

        if (userJobInfoDb != null)
        {
            _entityFramework.UserJobInfo.Remove(userJobInfoDb);
            if (_entityFramework.SaveChanges() > 0)
            {
                return Ok();
            }

            throw new Exception("Failed to Delete User JobInfo");
        }
        throw new Exception("Failed to Get User JobInfo");
    }
}