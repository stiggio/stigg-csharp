using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events.DataExport;

namespace Stigg.Client.Tests.Models.V1.Events.DataExport;

public class DataExportListModelsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataExportListModelsResponse
        {
            Data = new(
                [
                    new()
                    {
                        ID = "id",
                        DisplayName = "displayName",
                        Models = [new() { ID = "id", DisplayName = "displayName" }],
                    },
                ]
            ),
        };

        Data expectedData = new(
            [
                new()
                {
                    ID = "id",
                    DisplayName = "displayName",
                    Models = [new() { ID = "id", DisplayName = "displayName" }],
                },
            ]
        );

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DataExportListModelsResponse
        {
            Data = new(
                [
                    new()
                    {
                        ID = "id",
                        DisplayName = "displayName",
                        Models = [new() { ID = "id", DisplayName = "displayName" }],
                    },
                ]
            ),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataExportListModelsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataExportListModelsResponse
        {
            Data = new(
                [
                    new()
                    {
                        ID = "id",
                        DisplayName = "displayName",
                        Models = [new() { ID = "id", DisplayName = "displayName" }],
                    },
                ]
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataExportListModelsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new(
            [
                new()
                {
                    ID = "id",
                    DisplayName = "displayName",
                    Models = [new() { ID = "id", DisplayName = "displayName" }],
                },
            ]
        );

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DataExportListModelsResponse
        {
            Data = new(
                [
                    new()
                    {
                        ID = "id",
                        DisplayName = "displayName",
                        Models = [new() { ID = "id", DisplayName = "displayName" }],
                    },
                ]
            ),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DataExportListModelsResponse
        {
            Data = new(
                [
                    new()
                    {
                        ID = "id",
                        DisplayName = "displayName",
                        Models = [new() { ID = "id", DisplayName = "displayName" }],
                    },
                ]
            ),
        };

        DataExportListModelsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            Groups =
            [
                new()
                {
                    ID = "id",
                    DisplayName = "displayName",
                    Models = [new() { ID = "id", DisplayName = "displayName" }],
                },
            ],
        };

        List<Group> expectedGroups =
        [
            new()
            {
                ID = "id",
                DisplayName = "displayName",
                Models = [new() { ID = "id", DisplayName = "displayName" }],
            },
        ];

        Assert.Equal(expectedGroups.Count, model.Groups.Count);
        for (int i = 0; i < expectedGroups.Count; i++)
        {
            Assert.Equal(expectedGroups[i], model.Groups[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            Groups =
            [
                new()
                {
                    ID = "id",
                    DisplayName = "displayName",
                    Models = [new() { ID = "id", DisplayName = "displayName" }],
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
        {
            Groups =
            [
                new()
                {
                    ID = "id",
                    DisplayName = "displayName",
                    Models = [new() { ID = "id", DisplayName = "displayName" }],
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<Group> expectedGroups =
        [
            new()
            {
                ID = "id",
                DisplayName = "displayName",
                Models = [new() { ID = "id", DisplayName = "displayName" }],
            },
        ];

        Assert.Equal(expectedGroups.Count, deserialized.Groups.Count);
        for (int i = 0; i < expectedGroups.Count; i++)
        {
            Assert.Equal(expectedGroups[i], deserialized.Groups[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            Groups =
            [
                new()
                {
                    ID = "id",
                    DisplayName = "displayName",
                    Models = [new() { ID = "id", DisplayName = "displayName" }],
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            Groups =
            [
                new()
                {
                    ID = "id",
                    DisplayName = "displayName",
                    Models = [new() { ID = "id", DisplayName = "displayName" }],
                },
            ],
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GroupTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Group
        {
            ID = "id",
            DisplayName = "displayName",
            Models = [new() { ID = "id", DisplayName = "displayName" }],
        };

        string expectedID = "id";
        string expectedDisplayName = "displayName";
        List<Model> expectedModels = [new() { ID = "id", DisplayName = "displayName" }];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedModels.Count, model.Models.Count);
        for (int i = 0; i < expectedModels.Count; i++)
        {
            Assert.Equal(expectedModels[i], model.Models[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Group
        {
            ID = "id",
            DisplayName = "displayName",
            Models = [new() { ID = "id", DisplayName = "displayName" }],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Group>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Group
        {
            ID = "id",
            DisplayName = "displayName",
            Models = [new() { ID = "id", DisplayName = "displayName" }],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Group>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedDisplayName = "displayName";
        List<Model> expectedModels = [new() { ID = "id", DisplayName = "displayName" }];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedModels.Count, deserialized.Models.Count);
        for (int i = 0; i < expectedModels.Count; i++)
        {
            Assert.Equal(expectedModels[i], deserialized.Models[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Group
        {
            ID = "id",
            DisplayName = "displayName",
            Models = [new() { ID = "id", DisplayName = "displayName" }],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Group
        {
            ID = "id",
            DisplayName = "displayName",
            Models = [new() { ID = "id", DisplayName = "displayName" }],
        };

        Group copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ModelTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Model { ID = "id", DisplayName = "displayName" };

        string expectedID = "id";
        string expectedDisplayName = "displayName";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedDisplayName, model.DisplayName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Model { ID = "id", DisplayName = "displayName" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Model>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Model { ID = "id", DisplayName = "displayName" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Model>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedDisplayName = "displayName";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Model { ID = "id", DisplayName = "displayName" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Model { ID = "id", DisplayName = "displayName" };

        Model copied = new(model);

        Assert.Equal(model, copied);
    }
}
