using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using AQA_DIPLOMA.Configuration.Enums;
using Microsoft.Extensions.Configuration;

namespace AQA_DIPLOMA.Configuration;

public class Configurator
{
    private static readonly Lazy<IConfiguration> _configuration;
    private static List<User> _users = null!;
    private static AppSettings _appSettings = null!;
    private static IConfiguration Configuration => _configuration.Value;

    public static User Admin => _users.Find(user => user.UserType == UserType.Admin) ??
                                throw new NullReferenceException("Data not found. Check your appsetting.json file!");
    
    public static AppSettings AppSettings => _appSettings ??
                                             throw new NullReferenceException(
                                                 "Data not found. Check your appsetting.json file!");

    static Configurator()
    {
        _configuration = new Lazy<IConfiguration>(BuildConfiguration);
        BuildUsersList();
        BuildAppSettings();
    }

    private static IConfiguration BuildConfiguration()
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var builder = new ConfigurationBuilder().SetBasePath(basePath).AddJsonFile("appsettings.json");

        return builder.Build();
    }
    
    private static void BuildAppSettings()
    {
        var appSettingsSection = Configuration.GetSection(nameof(AppSettings));
        _appSettings = new AppSettings
        {
            BaseUrl = appSettingsSection["BaseUrl"],
            ApiUrl = appSettingsSection["ApiUrl"],
            BrowserType = appSettingsSection["BrowserType"],
            WaitTimeout = int.Parse(appSettingsSection["WaitTimeout"]!)
        };
    }
    
    private static void BuildUsersList()
    {
        var usersSection = Configuration.GetSection(nameof(User));
        _users = new List<User>();
        foreach (var usersArrayMember in usersSection.GetChildren())
        {
            var user = new User
            {
                Email = usersArrayMember["Email"],
                Password = usersArrayMember["Password"],
                Token = usersArrayMember["Token"]
            };
            user.UserType = usersArrayMember["UserType"]?.ToLower() switch
            {
                "admin" => UserType.Admin,
                _ => user.UserType
            };
            _users.Add(user);
        }
    }

    
}
