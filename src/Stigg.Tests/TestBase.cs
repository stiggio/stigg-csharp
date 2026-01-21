using System;
using Stigg;

namespace Stigg.Tests;

public class TestBase
{
    protected IStiggClient client;

    public TestBase()
    {
        client = new StiggClient()
        {
            BaseUrl =
                Environment.GetEnvironmentVariable("TEST_API_BASE_URL") ?? "http://localhost:4010",
            ApiKey = "My API Key",
        };
    }
}
