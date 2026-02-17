using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events.Features;

namespace Stigg.Client.Tests.Models.V1.Events.Features;

public class FeatureListFeaturesPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FeatureListFeaturesPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    DisplayName = "displayName",
                    EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
                    FeatureStatus = FeatureListFeaturesResponseFeatureStatus.New,
                    FeatureType = FeatureListFeaturesResponseFeatureType.Boolean,
                    FeatureUnits = "featureUnits",
                    FeatureUnitsPlural = "featureUnitsPlural",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    MeterType = FeatureListFeaturesResponseMeterType.None,
                    UnitTransformation = new()
                    {
                        Divide = 0,
                        FeatureUnits = "featureUnits",
                        FeatureUnitsPlural = "featureUnitsPlural",
                        Round = FeatureListFeaturesResponseUnitTransformationRound.Up,
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        List<FeatureListFeaturesResponse> expectedData =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
                FeatureStatus = FeatureListFeaturesResponseFeatureStatus.New,
                FeatureType = FeatureListFeaturesResponseFeatureType.Boolean,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterType = FeatureListFeaturesResponseMeterType.None,
                UnitTransformation = new()
                {
                    Divide = 0,
                    FeatureUnits = "featureUnits",
                    FeatureUnitsPlural = "featureUnitsPlural",
                    Round = FeatureListFeaturesResponseUnitTransformationRound.Up,
                },
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        Pagination expectedPagination = new()
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedPagination, model.Pagination);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FeatureListFeaturesPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    DisplayName = "displayName",
                    EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
                    FeatureStatus = FeatureListFeaturesResponseFeatureStatus.New,
                    FeatureType = FeatureListFeaturesResponseFeatureType.Boolean,
                    FeatureUnits = "featureUnits",
                    FeatureUnitsPlural = "featureUnitsPlural",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    MeterType = FeatureListFeaturesResponseMeterType.None,
                    UnitTransformation = new()
                    {
                        Divide = 0,
                        FeatureUnits = "featureUnits",
                        FeatureUnitsPlural = "featureUnitsPlural",
                        Round = FeatureListFeaturesResponseUnitTransformationRound.Up,
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureListFeaturesPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FeatureListFeaturesPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    DisplayName = "displayName",
                    EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
                    FeatureStatus = FeatureListFeaturesResponseFeatureStatus.New,
                    FeatureType = FeatureListFeaturesResponseFeatureType.Boolean,
                    FeatureUnits = "featureUnits",
                    FeatureUnitsPlural = "featureUnitsPlural",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    MeterType = FeatureListFeaturesResponseMeterType.None,
                    UnitTransformation = new()
                    {
                        Divide = 0,
                        FeatureUnits = "featureUnits",
                        FeatureUnitsPlural = "featureUnitsPlural",
                        Round = FeatureListFeaturesResponseUnitTransformationRound.Up,
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FeatureListFeaturesPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<FeatureListFeaturesResponse> expectedData =
        [
            new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
                FeatureStatus = FeatureListFeaturesResponseFeatureStatus.New,
                FeatureType = FeatureListFeaturesResponseFeatureType.Boolean,
                FeatureUnits = "featureUnits",
                FeatureUnitsPlural = "featureUnitsPlural",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MeterType = FeatureListFeaturesResponseMeterType.None,
                UnitTransformation = new()
                {
                    Divide = 0,
                    FeatureUnits = "featureUnits",
                    FeatureUnitsPlural = "featureUnitsPlural",
                    Round = FeatureListFeaturesResponseUnitTransformationRound.Up,
                },
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        Pagination expectedPagination = new()
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedPagination, deserialized.Pagination);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FeatureListFeaturesPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    DisplayName = "displayName",
                    EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
                    FeatureStatus = FeatureListFeaturesResponseFeatureStatus.New,
                    FeatureType = FeatureListFeaturesResponseFeatureType.Boolean,
                    FeatureUnits = "featureUnits",
                    FeatureUnitsPlural = "featureUnitsPlural",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    MeterType = FeatureListFeaturesResponseMeterType.None,
                    UnitTransformation = new()
                    {
                        Divide = 0,
                        FeatureUnits = "featureUnits",
                        FeatureUnitsPlural = "featureUnitsPlural",
                        Round = FeatureListFeaturesResponseUnitTransformationRound.Up,
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FeatureListFeaturesPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Description = "description",
                    DisplayName = "displayName",
                    EnumConfiguration = [new() { DisplayName = "displayName", Value = "value" }],
                    FeatureStatus = FeatureListFeaturesResponseFeatureStatus.New,
                    FeatureType = FeatureListFeaturesResponseFeatureType.Boolean,
                    FeatureUnits = "featureUnits",
                    FeatureUnitsPlural = "featureUnitsPlural",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    MeterType = FeatureListFeaturesResponseMeterType.None,
                    UnitTransformation = new()
                    {
                        Divide = 0,
                        FeatureUnits = "featureUnits",
                        FeatureUnitsPlural = "featureUnitsPlural",
                        Round = FeatureListFeaturesResponseUnitTransformationRound.Up,
                    },
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        FeatureListFeaturesPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PaginationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedNext = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedPrev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedNext, model.Next);
        Assert.Equal(expectedPrev, model.Prev);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pagination>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pagination>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedNext = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedPrev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedNext, deserialized.Next);
        Assert.Equal(expectedPrev, deserialized.Prev);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Pagination copied = new(model);

        Assert.Equal(model, copied);
    }
}
