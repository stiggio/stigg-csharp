using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Plans = Stigg.Client.Models.V1.Plans;

namespace Stigg.Client.Tests.Models.V1.Plans;

public class PlanTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Plans::Plan
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CompatibleAddonIds = ["string"],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DefaultTrialConfig = new()
                {
                    Duration = 0,
                    Units = Plans::DataDefaultTrialConfigUnits.Day,
                    Budget = new() { HasSoftLimit = true, Limit = 0 },
                    TrialEndBehavior = Plans::DataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
                },
                Description = "description",
                DisplayName = "displayName",
                Entitlements = [new() { ID = "id", Type = Plans::Type.Feature }],
                IsLatest = true,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                ParentPlanID = "parentPlanId",
                PricingType = Plans::DataPricingType.Free,
                ProductID = "productId",
                Status = Plans::DataStatus.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        Plans::Data expectedData = new()
        {
            ID = "id",
            BillingID = "billingId",
            CompatibleAddonIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultTrialConfig = new()
            {
                Duration = 0,
                Units = Plans::DataDefaultTrialConfigUnits.Day,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                TrialEndBehavior = Plans::DataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
            },
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = Plans::Type.Feature }],
            IsLatest = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = Plans::DataPricingType.Free,
            ProductID = "productId",
            Status = Plans::DataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Plans::Plan
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CompatibleAddonIds = ["string"],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DefaultTrialConfig = new()
                {
                    Duration = 0,
                    Units = Plans::DataDefaultTrialConfigUnits.Day,
                    Budget = new() { HasSoftLimit = true, Limit = 0 },
                    TrialEndBehavior = Plans::DataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
                },
                Description = "description",
                DisplayName = "displayName",
                Entitlements = [new() { ID = "id", Type = Plans::Type.Feature }],
                IsLatest = true,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                ParentPlanID = "parentPlanId",
                PricingType = Plans::DataPricingType.Free,
                ProductID = "productId",
                Status = Plans::DataStatus.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Plans::Plan>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Plans::Plan
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CompatibleAddonIds = ["string"],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DefaultTrialConfig = new()
                {
                    Duration = 0,
                    Units = Plans::DataDefaultTrialConfigUnits.Day,
                    Budget = new() { HasSoftLimit = true, Limit = 0 },
                    TrialEndBehavior = Plans::DataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
                },
                Description = "description",
                DisplayName = "displayName",
                Entitlements = [new() { ID = "id", Type = Plans::Type.Feature }],
                IsLatest = true,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                ParentPlanID = "parentPlanId",
                PricingType = Plans::DataPricingType.Free,
                ProductID = "productId",
                Status = Plans::DataStatus.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Plans::Plan>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Plans::Data expectedData = new()
        {
            ID = "id",
            BillingID = "billingId",
            CompatibleAddonIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultTrialConfig = new()
            {
                Duration = 0,
                Units = Plans::DataDefaultTrialConfigUnits.Day,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                TrialEndBehavior = Plans::DataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
            },
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = Plans::Type.Feature }],
            IsLatest = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = Plans::DataPricingType.Free,
            ProductID = "productId",
            Status = Plans::DataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Plans::Plan
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CompatibleAddonIds = ["string"],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DefaultTrialConfig = new()
                {
                    Duration = 0,
                    Units = Plans::DataDefaultTrialConfigUnits.Day,
                    Budget = new() { HasSoftLimit = true, Limit = 0 },
                    TrialEndBehavior = Plans::DataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
                },
                Description = "description",
                DisplayName = "displayName",
                Entitlements = [new() { ID = "id", Type = Plans::Type.Feature }],
                IsLatest = true,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                ParentPlanID = "parentPlanId",
                PricingType = Plans::DataPricingType.Free,
                ProductID = "productId",
                Status = Plans::DataStatus.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Plans::Plan
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CompatibleAddonIds = ["string"],
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DefaultTrialConfig = new()
                {
                    Duration = 0,
                    Units = Plans::DataDefaultTrialConfigUnits.Day,
                    Budget = new() { HasSoftLimit = true, Limit = 0 },
                    TrialEndBehavior = Plans::DataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
                },
                Description = "description",
                DisplayName = "displayName",
                Entitlements = [new() { ID = "id", Type = Plans::Type.Feature }],
                IsLatest = true,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                ParentPlanID = "parentPlanId",
                PricingType = Plans::DataPricingType.Free,
                ProductID = "productId",
                Status = Plans::DataStatus.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        Plans::Plan copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Plans::Data
        {
            ID = "id",
            BillingID = "billingId",
            CompatibleAddonIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultTrialConfig = new()
            {
                Duration = 0,
                Units = Plans::DataDefaultTrialConfigUnits.Day,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                TrialEndBehavior = Plans::DataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
            },
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = Plans::Type.Feature }],
            IsLatest = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = Plans::DataPricingType.Free,
            ProductID = "productId",
            Status = Plans::DataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        string expectedID = "id";
        string expectedBillingID = "billingId";
        List<string> expectedCompatibleAddonIds = ["string"];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Plans::DataDefaultTrialConfig expectedDefaultTrialConfig = new()
        {
            Duration = 0,
            Units = Plans::DataDefaultTrialConfigUnits.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior = Plans::DataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
        };
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        List<Plans::DataEntitlement> expectedEntitlements =
        [
            new() { ID = "id", Type = Plans::Type.Feature },
        ];
        bool expectedIsLatest = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedParentPlanID = "parentPlanId";
        ApiEnum<string, Plans::DataPricingType> expectedPricingType = Plans::DataPricingType.Free;
        string expectedProductID = "productId";
        ApiEnum<string, Plans::DataStatus> expectedStatus = Plans::DataStatus.Draft;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedVersionNumber = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillingID, model.BillingID);
        Assert.NotNull(model.CompatibleAddonIds);
        Assert.Equal(expectedCompatibleAddonIds.Count, model.CompatibleAddonIds.Count);
        for (int i = 0; i < expectedCompatibleAddonIds.Count; i++)
        {
            Assert.Equal(expectedCompatibleAddonIds[i], model.CompatibleAddonIds[i]);
        }
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDefaultTrialConfig, model.DefaultTrialConfig);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedEntitlements.Count, model.Entitlements.Count);
        for (int i = 0; i < expectedEntitlements.Count; i++)
        {
            Assert.Equal(expectedEntitlements[i], model.Entitlements[i]);
        }
        Assert.Equal(expectedIsLatest, model.IsLatest);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedParentPlanID, model.ParentPlanID);
        Assert.Equal(expectedPricingType, model.PricingType);
        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedVersionNumber, model.VersionNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Plans::Data
        {
            ID = "id",
            BillingID = "billingId",
            CompatibleAddonIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultTrialConfig = new()
            {
                Duration = 0,
                Units = Plans::DataDefaultTrialConfigUnits.Day,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                TrialEndBehavior = Plans::DataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
            },
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = Plans::Type.Feature }],
            IsLatest = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = Plans::DataPricingType.Free,
            ProductID = "productId",
            Status = Plans::DataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Plans::Data>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Plans::Data
        {
            ID = "id",
            BillingID = "billingId",
            CompatibleAddonIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultTrialConfig = new()
            {
                Duration = 0,
                Units = Plans::DataDefaultTrialConfigUnits.Day,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                TrialEndBehavior = Plans::DataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
            },
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = Plans::Type.Feature }],
            IsLatest = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = Plans::DataPricingType.Free,
            ProductID = "productId",
            Status = Plans::DataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Plans::Data>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedBillingID = "billingId";
        List<string> expectedCompatibleAddonIds = ["string"];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Plans::DataDefaultTrialConfig expectedDefaultTrialConfig = new()
        {
            Duration = 0,
            Units = Plans::DataDefaultTrialConfigUnits.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior = Plans::DataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
        };
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        List<Plans::DataEntitlement> expectedEntitlements =
        [
            new() { ID = "id", Type = Plans::Type.Feature },
        ];
        bool expectedIsLatest = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedParentPlanID = "parentPlanId";
        ApiEnum<string, Plans::DataPricingType> expectedPricingType = Plans::DataPricingType.Free;
        string expectedProductID = "productId";
        ApiEnum<string, Plans::DataStatus> expectedStatus = Plans::DataStatus.Draft;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedVersionNumber = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBillingID, deserialized.BillingID);
        Assert.NotNull(deserialized.CompatibleAddonIds);
        Assert.Equal(expectedCompatibleAddonIds.Count, deserialized.CompatibleAddonIds.Count);
        for (int i = 0; i < expectedCompatibleAddonIds.Count; i++)
        {
            Assert.Equal(expectedCompatibleAddonIds[i], deserialized.CompatibleAddonIds[i]);
        }
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDefaultTrialConfig, deserialized.DefaultTrialConfig);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedEntitlements.Count, deserialized.Entitlements.Count);
        for (int i = 0; i < expectedEntitlements.Count; i++)
        {
            Assert.Equal(expectedEntitlements[i], deserialized.Entitlements[i]);
        }
        Assert.Equal(expectedIsLatest, deserialized.IsLatest);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedParentPlanID, deserialized.ParentPlanID);
        Assert.Equal(expectedPricingType, deserialized.PricingType);
        Assert.Equal(expectedProductID, deserialized.ProductID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedVersionNumber, deserialized.VersionNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Plans::Data
        {
            ID = "id",
            BillingID = "billingId",
            CompatibleAddonIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultTrialConfig = new()
            {
                Duration = 0,
                Units = Plans::DataDefaultTrialConfigUnits.Day,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                TrialEndBehavior = Plans::DataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
            },
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = Plans::Type.Feature }],
            IsLatest = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = Plans::DataPricingType.Free,
            ProductID = "productId",
            Status = Plans::DataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Plans::Data
        {
            ID = "id",
            BillingID = "billingId",
            CompatibleAddonIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultTrialConfig = new()
            {
                Duration = 0,
                Units = Plans::DataDefaultTrialConfigUnits.Day,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                TrialEndBehavior = Plans::DataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
            },
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = Plans::Type.Feature }],
            IsLatest = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = Plans::DataPricingType.Free,
            ProductID = "productId",
            Status = Plans::DataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        Plans::Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataDefaultTrialConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Plans::DataDefaultTrialConfig
        {
            Duration = 0,
            Units = Plans::DataDefaultTrialConfigUnits.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior = Plans::DataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
        };

        double expectedDuration = 0;
        ApiEnum<string, Plans::DataDefaultTrialConfigUnits> expectedUnits =
            Plans::DataDefaultTrialConfigUnits.Day;
        Plans::DataDefaultTrialConfigBudget expectedBudget = new()
        {
            HasSoftLimit = true,
            Limit = 0,
        };
        ApiEnum<string, Plans::DataDefaultTrialConfigTrialEndBehavior> expectedTrialEndBehavior =
            Plans::DataDefaultTrialConfigTrialEndBehavior.ConvertToPaid;

        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedUnits, model.Units);
        Assert.Equal(expectedBudget, model.Budget);
        Assert.Equal(expectedTrialEndBehavior, model.TrialEndBehavior);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Plans::DataDefaultTrialConfig
        {
            Duration = 0,
            Units = Plans::DataDefaultTrialConfigUnits.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior = Plans::DataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Plans::DataDefaultTrialConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Plans::DataDefaultTrialConfig
        {
            Duration = 0,
            Units = Plans::DataDefaultTrialConfigUnits.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior = Plans::DataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Plans::DataDefaultTrialConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedDuration = 0;
        ApiEnum<string, Plans::DataDefaultTrialConfigUnits> expectedUnits =
            Plans::DataDefaultTrialConfigUnits.Day;
        Plans::DataDefaultTrialConfigBudget expectedBudget = new()
        {
            HasSoftLimit = true,
            Limit = 0,
        };
        ApiEnum<string, Plans::DataDefaultTrialConfigTrialEndBehavior> expectedTrialEndBehavior =
            Plans::DataDefaultTrialConfigTrialEndBehavior.ConvertToPaid;

        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedUnits, deserialized.Units);
        Assert.Equal(expectedBudget, deserialized.Budget);
        Assert.Equal(expectedTrialEndBehavior, deserialized.TrialEndBehavior);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Plans::DataDefaultTrialConfig
        {
            Duration = 0,
            Units = Plans::DataDefaultTrialConfigUnits.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior = Plans::DataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Plans::DataDefaultTrialConfig
        {
            Duration = 0,
            Units = Plans::DataDefaultTrialConfigUnits.Day,
        };

        Assert.Null(model.Budget);
        Assert.False(model.RawData.ContainsKey("budget"));
        Assert.Null(model.TrialEndBehavior);
        Assert.False(model.RawData.ContainsKey("trialEndBehavior"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Plans::DataDefaultTrialConfig
        {
            Duration = 0,
            Units = Plans::DataDefaultTrialConfigUnits.Day,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Plans::DataDefaultTrialConfig
        {
            Duration = 0,
            Units = Plans::DataDefaultTrialConfigUnits.Day,

            Budget = null,
            TrialEndBehavior = null,
        };

        Assert.Null(model.Budget);
        Assert.True(model.RawData.ContainsKey("budget"));
        Assert.Null(model.TrialEndBehavior);
        Assert.True(model.RawData.ContainsKey("trialEndBehavior"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Plans::DataDefaultTrialConfig
        {
            Duration = 0,
            Units = Plans::DataDefaultTrialConfigUnits.Day,

            Budget = null,
            TrialEndBehavior = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Plans::DataDefaultTrialConfig
        {
            Duration = 0,
            Units = Plans::DataDefaultTrialConfigUnits.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior = Plans::DataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
        };

        Plans::DataDefaultTrialConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataDefaultTrialConfigUnitsTest : TestBase
{
    [Theory]
    [InlineData(Plans::DataDefaultTrialConfigUnits.Day)]
    [InlineData(Plans::DataDefaultTrialConfigUnits.Month)]
    public void Validation_Works(Plans::DataDefaultTrialConfigUnits rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Plans::DataDefaultTrialConfigUnits> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Plans::DataDefaultTrialConfigUnits>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Plans::DataDefaultTrialConfigUnits.Day)]
    [InlineData(Plans::DataDefaultTrialConfigUnits.Month)]
    public void SerializationRoundtrip_Works(Plans::DataDefaultTrialConfigUnits rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Plans::DataDefaultTrialConfigUnits> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Plans::DataDefaultTrialConfigUnits>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Plans::DataDefaultTrialConfigUnits>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Plans::DataDefaultTrialConfigUnits>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DataDefaultTrialConfigBudgetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Plans::DataDefaultTrialConfigBudget { HasSoftLimit = true, Limit = 0 };

        bool expectedHasSoftLimit = true;
        double expectedLimit = 0;

        Assert.Equal(expectedHasSoftLimit, model.HasSoftLimit);
        Assert.Equal(expectedLimit, model.Limit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Plans::DataDefaultTrialConfigBudget { HasSoftLimit = true, Limit = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Plans::DataDefaultTrialConfigBudget>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Plans::DataDefaultTrialConfigBudget { HasSoftLimit = true, Limit = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Plans::DataDefaultTrialConfigBudget>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedHasSoftLimit = true;
        double expectedLimit = 0;

        Assert.Equal(expectedHasSoftLimit, deserialized.HasSoftLimit);
        Assert.Equal(expectedLimit, deserialized.Limit);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Plans::DataDefaultTrialConfigBudget { HasSoftLimit = true, Limit = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Plans::DataDefaultTrialConfigBudget { HasSoftLimit = true, Limit = 0 };

        Plans::DataDefaultTrialConfigBudget copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataDefaultTrialConfigTrialEndBehaviorTest : TestBase
{
    [Theory]
    [InlineData(Plans::DataDefaultTrialConfigTrialEndBehavior.ConvertToPaid)]
    [InlineData(Plans::DataDefaultTrialConfigTrialEndBehavior.CancelSubscription)]
    public void Validation_Works(Plans::DataDefaultTrialConfigTrialEndBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Plans::DataDefaultTrialConfigTrialEndBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Plans::DataDefaultTrialConfigTrialEndBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Plans::DataDefaultTrialConfigTrialEndBehavior.ConvertToPaid)]
    [InlineData(Plans::DataDefaultTrialConfigTrialEndBehavior.CancelSubscription)]
    public void SerializationRoundtrip_Works(Plans::DataDefaultTrialConfigTrialEndBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Plans::DataDefaultTrialConfigTrialEndBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Plans::DataDefaultTrialConfigTrialEndBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Plans::DataDefaultTrialConfigTrialEndBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Plans::DataDefaultTrialConfigTrialEndBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DataEntitlementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Plans::DataEntitlement { ID = "id", Type = Plans::Type.Feature };

        string expectedID = "id";
        ApiEnum<string, Plans::Type> expectedType = Plans::Type.Feature;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Plans::DataEntitlement { ID = "id", Type = Plans::Type.Feature };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Plans::DataEntitlement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Plans::DataEntitlement { ID = "id", Type = Plans::Type.Feature };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Plans::DataEntitlement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, Plans::Type> expectedType = Plans::Type.Feature;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Plans::DataEntitlement { ID = "id", Type = Plans::Type.Feature };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Plans::DataEntitlement { ID = "id", Type = Plans::Type.Feature };

        Plans::DataEntitlement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Plans::Type.Feature)]
    [InlineData(Plans::Type.Credit)]
    public void Validation_Works(Plans::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Plans::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Plans::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Plans::Type.Feature)]
    [InlineData(Plans::Type.Credit)]
    public void SerializationRoundtrip_Works(Plans::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Plans::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Plans::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Plans::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Plans::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataPricingTypeTest : TestBase
{
    [Theory]
    [InlineData(Plans::DataPricingType.Free)]
    [InlineData(Plans::DataPricingType.Paid)]
    [InlineData(Plans::DataPricingType.Custom)]
    public void Validation_Works(Plans::DataPricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Plans::DataPricingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Plans::DataPricingType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Plans::DataPricingType.Free)]
    [InlineData(Plans::DataPricingType.Paid)]
    [InlineData(Plans::DataPricingType.Custom)]
    public void SerializationRoundtrip_Works(Plans::DataPricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Plans::DataPricingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Plans::DataPricingType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Plans::DataPricingType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Plans::DataPricingType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataStatusTest : TestBase
{
    [Theory]
    [InlineData(Plans::DataStatus.Draft)]
    [InlineData(Plans::DataStatus.Published)]
    [InlineData(Plans::DataStatus.Archived)]
    public void Validation_Works(Plans::DataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Plans::DataStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Plans::DataStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Plans::DataStatus.Draft)]
    [InlineData(Plans::DataStatus.Published)]
    [InlineData(Plans::DataStatus.Archived)]
    public void SerializationRoundtrip_Works(Plans::DataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Plans::DataStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Plans::DataStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Plans::DataStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Plans::DataStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
