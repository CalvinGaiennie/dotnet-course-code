using DotnetApi.Data;
using DotnetApi.Dtos;
using DotnetApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    DataContextDapper _dapper;
    public UserController(IConfiguration config)
    {
        _dapper = new DataContextDapper(config);
    }

    [HttpGet("TestConnection")]
    public DateTime TestConnection()
    {
        return _dapper.LoadDataSingle<DateTime>("SELECT GETDATE()");
    }

    [HttpGet("GetUsers")]
    public IEnumerable<User> GetUsers()
    {
        string sql = @"SELECT * FROM TutorialAppSchema.Users";

        IEnumerable<User> users = _dapper.LoadData<User>(sql);

        return users;

    }
    [HttpGet("GetSingleUser/{userId}")]
    public User GetSingleUser(int userId)
    {
        string sql = @"SELECT * FROM TutorialAppSchema.Users WHERE UserId = " + userId.ToString();

        User user = _dapper.LoadDataSingle<User>(sql);

        return user;
    }

    [HttpPut("EditUser")]
    public IActionResult EditUser(User user)
    {
        string sql = @"
        UPDATE TutorialAppSchema.Users 
            SET[FirstName] = '" + user.FirstName +
                @"', [LastName] = '" + user.LastName +
                @"', [Email] = '" + user.Email +
                @"', [Gender] = '" + user.Gender +
                @"', [Active] = '" + user.Active +
            "' WHERE UserId = " + user.UserId.ToString();

        if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        }
        throw new Exception("Failed to Update User");
    }

    [HttpPost("AddUser")]
    public IActionResult AddUser(UserDto user)
    {
        string sql = @"INSERT INTO TutorialAppSchema.Users(        
            [FirstName], 
            [LastName], 
            [Email], 
            [Gender], 
            [Active]
        ) VALUES (" +
            "'" + user.FirstName +
            "','" + user.LastName +
            "','" + user.Email +
            "','" + user.Gender +
            "','" + user.Active +
        "')";

        if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        }

        throw new Exception("Failed to Add User");
    }

    [HttpDelete("DeleteUser/{userId}")]
    public IActionResult DeleteUser(int userId)
    {
        string sql = @"DELETE FROM TutorialAppSchema.Users WHERE UserId = " + userId;

        if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        }

        throw new Exception("Failed to Delete User");
    }

    //////////////////////////////////////////
    /// Salary
    //////////////////////////////////////////

    [HttpGet("UserSalary/{userId}")]
    public IActionResult GetUserSalary(int userId)
    {
        string sql = @"SELECT UserSalary.UserId,
            UserSalary.Salary
        FROM TutorialAppSchema.UserSalary
        WHERE UserSalary.UserId = " + userId.ToString();

        IEnumerable<UserSalary> userSalary = _dapper.LoadData<UserSalary>(sql);

        return Ok(userSalary);
    }

    [HttpPost("UserSalary")]
    public IActionResult PostUserSalary(UserSalary userSalaryForInsert)
    {
        string sql = @"
        INSERT INTO TutorialAppSchema.UserSalary(
            UserId,
            Salary
        ) VALUES (" + userSalaryForInsert.UserId
            + ", " + userSalaryForInsert.Salary
            + ")";

        if (_dapper.ExecuteSql(sql))
        {
            return Ok(userSalaryForInsert);
        }

        throw new Exception("Failed to Add User Salary");
    }
    [HttpPut("UserSalary")]
    public IActionResult PutUserSalary(UserSalary userSalaryForUpdate)
    {
        string sql = @"
        UPDATE TutorialAppSchema.UserSalary
        SET Salary = " + userSalaryForUpdate.Salary +
        " WHERE UserId = " + userSalaryForUpdate.UserId.ToString();

        if (_dapper.ExecuteSql(sql))
        {
            return Ok(userSalaryForUpdate);
        }

        throw new Exception("Failed to Update User Salary");
    }
    [HttpDelete("UserSalary/{userId}")]
    public IActionResult DeleteUserSalary(int userId)
    {
        string sql = @"DELETE FROM TutorialAppSchema.UserSalary WHERE UserId = " + userId;

        if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        }

        throw new Exception("Failed to Delete User Salary");
    }

    //////////////////////////////////////////
    /// User Job Info
    //////////////////////////////////////////

    [HttpGet("UserJobInfo/{userId}")]
    public IActionResult GetUserJobInfo(int userId)
    {
        string sql = @"SELECT UserJobInfo.UserId,
            UserJobInfo.JobTitle,
            UserJobInfo.Department
        FROM TutorialAppSchema.UserJobInfo
        WHERE UserId = " + userId.ToString();

        UserJobInfo userJobInfo = _dapper.LoadDataSingle<UserJobInfo>(sql);

        return Ok(userJobInfo);
    }

    [HttpPost("UserJobInfo")]
    public IActionResult PostUserJobInfo(UserJobInfo userJobInfoForInsert)
    {
        string sql = @"
        INSERT INTO TutorialAppSchema.UserJobInfo(
            UserId,
            Department,
            JobTitle
        ) VALUES (" + userJobInfoForInsert.UserId
            + ", '" + userJobInfoForInsert.Department
            + "', '" + userJobInfoForInsert.JobTitle
            + "')";

        if (_dapper.ExecuteSql(sql))
        {
            return Ok(userJobInfoForInsert);
        }

        throw new Exception("Failed to Add User JobInfo");
    }
    [HttpPut("UserJobInfo")]
    public IActionResult PutUserJobInfo(UserJobInfo userJobInfoForUpdate)
    {
        string sql = @"
        UPDATE TutorialAppSchema.UserJobInfo
        SET Department = '" + userJobInfoForUpdate.Department +
        "', JobTitle = '" + userJobInfoForUpdate.JobTitle +
        "' WHERE UserId = " + userJobInfoForUpdate.UserId.ToString();

        if (_dapper.ExecuteSql(sql))
        {
            return Ok(userJobInfoForUpdate);
        }

        throw new Exception("Failed to Update User JobInfo");
    }
    [HttpDelete("UserJobInfo/{userId}")]
    public IActionResult DeleteUserJobInfo(int userId)
    {
        string sql = @"DELETE FROM TutorialAppSchema.UserJobInfo WHERE UserId = " + userId.ToString();

        if (_dapper.ExecuteSql(sql))
        {
            return Ok();
        }

        throw new Exception("Failed to Delete User JobInfo");
    }
}