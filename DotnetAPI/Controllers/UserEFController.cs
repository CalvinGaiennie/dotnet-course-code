using DotnetApi.Data;
using DotnetApi.Dtos;
using DotnetApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserEFController : ControllerBase
{
    IUserRepository _userRepository;
    public UserEFController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("GetUsers")]
    public IEnumerable<User> GetUsers()
    {
        IEnumerable<User> users = _userRepository.GetUsers();
        return users;
    }
    [HttpGet("GetSingleUser/{userId}")]
    public User GetSingleUser(int userId)
    {
        return _userRepository.GetSingleUser(userId);
    }

    [HttpPut("EditUser")]
    public IActionResult EditUser(User user)
    {
        User? userDb = _userRepository.GetSingleUser(user.UserId);

        if (userDb != null)
        {
            userDb.Active = user.Active;
            userDb.FirstName = user.FirstName;
            userDb.LastName = user.LastName;
            userDb.Email = user.Email;
            userDb.Gender = user.Gender;
            if (_userRepository.SaveChanges())
            {
                return Ok();
            }

            throw new Exception("Failed to Update User");
        }
        throw new Exception("Failed to Get User");
    }

    [HttpPost("AddUser")]
    public IActionResult AddUser(UserToAddDto user)
    {
        User userDb = new User();

        userDb.Active = user.Active;
        userDb.FirstName = user.FirstName;
        userDb.LastName = user.LastName;
        userDb.Email = user.Email;
        userDb.Gender = user.Gender;
        _userRepository.AddEntity<User>(userDb);

        if (_userRepository.SaveChanges())
        {
            return Ok();
        }

        throw new Exception("Failed to Add User");
    }

    [HttpDelete("DeleteUser/{userId}")]
    public IActionResult DeleteUser(int userId)
    {
        User? userDb = _userRepository.GetSingleUser(userId);

        if (userDb != null)
        {
            _userRepository.RemoveEntity<User>(userDb);
            if (_userRepository.SaveChanges())
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
    public UserSalary GetUserSalary(int userId)
    {
        return _userRepository.GetSingleUserSalary(userId);
    }

    [HttpPost("UserSalary")]
    public IActionResult PostUserSalaryEF(UserSalary userSalaryForInsert)
    {
        _userRepository.AddEntity<UserSalary>(userSalaryForInsert);
        if (_userRepository.SaveChanges())
        {
            return Ok(userSalaryForInsert);
        }

        throw new Exception("Failed to Add User Salary");
    }

    [HttpPut("UserSalary")]
    public IActionResult PutUserSalary(UserSalary userForUpdate)
    {
        UserSalary? userToUpdate = _userRepository.GetSingleUserSalary(userForUpdate.UserId);

        if (userToUpdate != null)
        {
            userToUpdate.Salary = userForUpdate.Salary;
            if (_userRepository.SaveChanges())
            {
                return Ok(userForUpdate);
            }

            throw new Exception("Failed to Update User Salary");
        }
        throw new Exception("Failed to Get User Salary");
    }

    [HttpDelete("UserSalary/{userId}")]
    public IActionResult DeleteUserSalary(int userId)
    {
        UserSalary? userToDelete = _userRepository.GetSingleUserSalary(userId);

        if (userToDelete != null)
        {
            _userRepository.RemoveEntity<UserSalary>(userToDelete);
            if (_userRepository.SaveChanges())
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
    public UserJobInfo GetUserJobInfo(int userId)
    {
        return _userRepository.GetSingleUserJobInfo(userId);
    }

    [HttpPost("UserJobInfo")]
    public IActionResult PostUserJobInfo(UserJobInfo userJobInfoForInsert)
    {
        UserJobInfo userJobInfoDb = new UserJobInfo();

        userJobInfoDb.UserId = userJobInfoForInsert.UserId;
        userJobInfoDb.Department = userJobInfoForInsert.Department;
        userJobInfoDb.JobTitle = userJobInfoForInsert.JobTitle;
        _userRepository.AddEntity<UserJobInfo>(userJobInfoDb);

        if (_userRepository.SaveChanges())
        {
            return Ok(userJobInfoForInsert);
        }

        throw new Exception("Failed to Add User JobInfo");
    }

    [HttpPut("UserJobInfo")]
    public IActionResult PutUserJobInfo(UserJobInfo userJobInfoForUpdate)
    {
        UserJobInfo? userForUpdate = _userRepository.GetSingleUserJobInfo(userJobInfoForUpdate.UserId);

        if (userForUpdate != null)
        {
            userForUpdate.Department = userJobInfoForUpdate.Department;
            userForUpdate.JobTitle = userJobInfoForUpdate.JobTitle;
            if (_userRepository.SaveChanges())
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
        UserJobInfo? userToDelete = _userRepository.GetSingleUserJobInfo(userId);

        if (userToDelete != null)
        {
            _userRepository.RemoveEntity<UserJobInfo>(userToDelete);
            if (_userRepository.SaveChanges())
            {
                return Ok();
            }

            throw new Exception("Failed to Delete User JobInfo");
        }
        throw new Exception("Failed to Get User JobInfo");
    }
}