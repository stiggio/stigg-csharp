using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Events.Plans;

namespace Stigg.Client.Tests.Models.V1.Events.Plans;

public class PlanRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanRetrieveResponse
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
                    Units = PlanRetrieveResponseDataDefaultTrialConfigUnits.Day,
                    Budget = new() { HasSoftLimit = true, Limit = 0 },
                    TrialEndBehavior =
                        PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
                },
                Description = "description",
                DisplayName = "displayName",
                Entitlements =
                [
                    new() { ID = "id", Type = PlanRetrieveResponseDataEntitlementType.Feature },
                ],
                IsLatest = true,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                ParentPlanID = "parentPlanId",
                PricingType = PlanRetrieveResponseDataPricingType.Free,
                ProductID = "productId",
                Status = PlanRetrieveResponseDataStatus.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        PlanRetrieveResponseData expectedData = new()
        {
            ID = "id",
            BillingID = "billingId",
            CompatibleAddonIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultTrialConfig = new()
            {
                Duration = 0,
                Units = PlanRetrieveResponseDataDefaultTrialConfigUnits.Day,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                TrialEndBehavior =
                    PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
            },
            Description = "description",
            DisplayName = "displayName",
            Entitlements =
            [
                new() { ID = "id", Type = PlanRetrieveResponseDataEntitlementType.Feature },
            ],
            IsLatest = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = PlanRetrieveResponseDataPricingType.Free,
            ProductID = "productId",
            Status = PlanRetrieveResponseDataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanRetrieveResponse
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
                    Units = PlanRetrieveResponseDataDefaultTrialConfigUnits.Day,
                    Budget = new() { HasSoftLimit = true, Limit = 0 },
                    TrialEndBehavior =
                        PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
                },
                Description = "description",
                DisplayName = "displayName",
                Entitlements =
                [
                    new() { ID = "id", Type = PlanRetrieveResponseDataEntitlementType.Feature },
                ],
                IsLatest = true,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                ParentPlanID = "parentPlanId",
                PricingType = PlanRetrieveResponseDataPricingType.Free,
                ProductID = "productId",
                Status = PlanRetrieveResponseDataStatus.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanRetrieveResponse
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
                    Units = PlanRetrieveResponseDataDefaultTrialConfigUnits.Day,
                    Budget = new() { HasSoftLimit = true, Limit = 0 },
                    TrialEndBehavior =
                        PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
                },
                Description = "description",
                DisplayName = "displayName",
                Entitlements =
                [
                    new() { ID = "id", Type = PlanRetrieveResponseDataEntitlementType.Feature },
                ],
                IsLatest = true,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                ParentPlanID = "parentPlanId",
                PricingType = PlanRetrieveResponseDataPricingType.Free,
                ProductID = "productId",
                Status = PlanRetrieveResponseDataStatus.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        PlanRetrieveResponseData expectedData = new()
        {
            ID = "id",
            BillingID = "billingId",
            CompatibleAddonIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultTrialConfig = new()
            {
                Duration = 0,
                Units = PlanRetrieveResponseDataDefaultTrialConfigUnits.Day,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                TrialEndBehavior =
                    PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
            },
            Description = "description",
            DisplayName = "displayName",
            Entitlements =
            [
                new() { ID = "id", Type = PlanRetrieveResponseDataEntitlementType.Feature },
            ],
            IsLatest = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = PlanRetrieveResponseDataPricingType.Free,
            ProductID = "productId",
            Status = PlanRetrieveResponseDataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanRetrieveResponse
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
                    Units = PlanRetrieveResponseDataDefaultTrialConfigUnits.Day,
                    Budget = new() { HasSoftLimit = true, Limit = 0 },
                    TrialEndBehavior =
                        PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
                },
                Description = "description",
                DisplayName = "displayName",
                Entitlements =
                [
                    new() { ID = "id", Type = PlanRetrieveResponseDataEntitlementType.Feature },
                ],
                IsLatest = true,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                ParentPlanID = "parentPlanId",
                PricingType = PlanRetrieveResponseDataPricingType.Free,
                ProductID = "productId",
                Status = PlanRetrieveResponseDataStatus.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlanRetrieveResponse
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
                    Units = PlanRetrieveResponseDataDefaultTrialConfigUnits.Day,
                    Budget = new() { HasSoftLimit = true, Limit = 0 },
                    TrialEndBehavior =
                        PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
                },
                Description = "description",
                DisplayName = "displayName",
                Entitlements =
                [
                    new() { ID = "id", Type = PlanRetrieveResponseDataEntitlementType.Feature },
                ],
                IsLatest = true,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                ParentPlanID = "parentPlanId",
                PricingType = PlanRetrieveResponseDataPricingType.Free,
                ProductID = "productId",
                Status = PlanRetrieveResponseDataStatus.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        PlanRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanRetrieveResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanRetrieveResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CompatibleAddonIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultTrialConfig = new()
            {
                Duration = 0,
                Units = PlanRetrieveResponseDataDefaultTrialConfigUnits.Day,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                TrialEndBehavior =
                    PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
            },
            Description = "description",
            DisplayName = "displayName",
            Entitlements =
            [
                new() { ID = "id", Type = PlanRetrieveResponseDataEntitlementType.Feature },
            ],
            IsLatest = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = PlanRetrieveResponseDataPricingType.Free,
            ProductID = "productId",
            Status = PlanRetrieveResponseDataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        string expectedID = "id";
        string expectedBillingID = "billingId";
        List<string> expectedCompatibleAddonIds = ["string"];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        PlanRetrieveResponseDataDefaultTrialConfig expectedDefaultTrialConfig = new()
        {
            Duration = 0,
            Units = PlanRetrieveResponseDataDefaultTrialConfigUnits.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior =
                PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
        };
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        List<PlanRetrieveResponseDataEntitlement> expectedEntitlements =
        [
            new() { ID = "id", Type = PlanRetrieveResponseDataEntitlementType.Feature },
        ];
        bool expectedIsLatest = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedParentPlanID = "parentPlanId";
        ApiEnum<string, PlanRetrieveResponseDataPricingType> expectedPricingType =
            PlanRetrieveResponseDataPricingType.Free;
        string expectedProductID = "productId";
        ApiEnum<string, PlanRetrieveResponseDataStatus> expectedStatus =
            PlanRetrieveResponseDataStatus.Draft;
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
        var model = new PlanRetrieveResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CompatibleAddonIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultTrialConfig = new()
            {
                Duration = 0,
                Units = PlanRetrieveResponseDataDefaultTrialConfigUnits.Day,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                TrialEndBehavior =
                    PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
            },
            Description = "description",
            DisplayName = "displayName",
            Entitlements =
            [
                new() { ID = "id", Type = PlanRetrieveResponseDataEntitlementType.Feature },
            ],
            IsLatest = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = PlanRetrieveResponseDataPricingType.Free,
            ProductID = "productId",
            Status = PlanRetrieveResponseDataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanRetrieveResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanRetrieveResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CompatibleAddonIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultTrialConfig = new()
            {
                Duration = 0,
                Units = PlanRetrieveResponseDataDefaultTrialConfigUnits.Day,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                TrialEndBehavior =
                    PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
            },
            Description = "description",
            DisplayName = "displayName",
            Entitlements =
            [
                new() { ID = "id", Type = PlanRetrieveResponseDataEntitlementType.Feature },
            ],
            IsLatest = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = PlanRetrieveResponseDataPricingType.Free,
            ProductID = "productId",
            Status = PlanRetrieveResponseDataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanRetrieveResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedBillingID = "billingId";
        List<string> expectedCompatibleAddonIds = ["string"];
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        PlanRetrieveResponseDataDefaultTrialConfig expectedDefaultTrialConfig = new()
        {
            Duration = 0,
            Units = PlanRetrieveResponseDataDefaultTrialConfigUnits.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior =
                PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
        };
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        List<PlanRetrieveResponseDataEntitlement> expectedEntitlements =
        [
            new() { ID = "id", Type = PlanRetrieveResponseDataEntitlementType.Feature },
        ];
        bool expectedIsLatest = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedParentPlanID = "parentPlanId";
        ApiEnum<string, PlanRetrieveResponseDataPricingType> expectedPricingType =
            PlanRetrieveResponseDataPricingType.Free;
        string expectedProductID = "productId";
        ApiEnum<string, PlanRetrieveResponseDataStatus> expectedStatus =
            PlanRetrieveResponseDataStatus.Draft;
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
        var model = new PlanRetrieveResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CompatibleAddonIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultTrialConfig = new()
            {
                Duration = 0,
                Units = PlanRetrieveResponseDataDefaultTrialConfigUnits.Day,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                TrialEndBehavior =
                    PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
            },
            Description = "description",
            DisplayName = "displayName",
            Entitlements =
            [
                new() { ID = "id", Type = PlanRetrieveResponseDataEntitlementType.Feature },
            ],
            IsLatest = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = PlanRetrieveResponseDataPricingType.Free,
            ProductID = "productId",
            Status = PlanRetrieveResponseDataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlanRetrieveResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CompatibleAddonIds = ["string"],
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultTrialConfig = new()
            {
                Duration = 0,
                Units = PlanRetrieveResponseDataDefaultTrialConfigUnits.Day,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                TrialEndBehavior =
                    PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
            },
            Description = "description",
            DisplayName = "displayName",
            Entitlements =
            [
                new() { ID = "id", Type = PlanRetrieveResponseDataEntitlementType.Feature },
            ],
            IsLatest = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = PlanRetrieveResponseDataPricingType.Free,
            ProductID = "productId",
            Status = PlanRetrieveResponseDataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        PlanRetrieveResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanRetrieveResponseDataDefaultTrialConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanRetrieveResponseDataDefaultTrialConfig
        {
            Duration = 0,
            Units = PlanRetrieveResponseDataDefaultTrialConfigUnits.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior =
                PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
        };

        double expectedDuration = 0;
        ApiEnum<string, PlanRetrieveResponseDataDefaultTrialConfigUnits> expectedUnits =
            PlanRetrieveResponseDataDefaultTrialConfigUnits.Day;
        PlanRetrieveResponseDataDefaultTrialConfigBudget expectedBudget = new()
        {
            HasSoftLimit = true,
            Limit = 0,
        };
        ApiEnum<
            string,
            PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior
        > expectedTrialEndBehavior =
            PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior.ConvertToPaid;

        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedUnits, model.Units);
        Assert.Equal(expectedBudget, model.Budget);
        Assert.Equal(expectedTrialEndBehavior, model.TrialEndBehavior);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanRetrieveResponseDataDefaultTrialConfig
        {
            Duration = 0,
            Units = PlanRetrieveResponseDataDefaultTrialConfigUnits.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior =
                PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanRetrieveResponseDataDefaultTrialConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanRetrieveResponseDataDefaultTrialConfig
        {
            Duration = 0,
            Units = PlanRetrieveResponseDataDefaultTrialConfigUnits.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior =
                PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanRetrieveResponseDataDefaultTrialConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedDuration = 0;
        ApiEnum<string, PlanRetrieveResponseDataDefaultTrialConfigUnits> expectedUnits =
            PlanRetrieveResponseDataDefaultTrialConfigUnits.Day;
        PlanRetrieveResponseDataDefaultTrialConfigBudget expectedBudget = new()
        {
            HasSoftLimit = true,
            Limit = 0,
        };
        ApiEnum<
            string,
            PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior
        > expectedTrialEndBehavior =
            PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior.ConvertToPaid;

        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedUnits, deserialized.Units);
        Assert.Equal(expectedBudget, deserialized.Budget);
        Assert.Equal(expectedTrialEndBehavior, deserialized.TrialEndBehavior);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanRetrieveResponseDataDefaultTrialConfig
        {
            Duration = 0,
            Units = PlanRetrieveResponseDataDefaultTrialConfigUnits.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior =
                PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PlanRetrieveResponseDataDefaultTrialConfig
        {
            Duration = 0,
            Units = PlanRetrieveResponseDataDefaultTrialConfigUnits.Day,
        };

        Assert.Null(model.Budget);
        Assert.False(model.RawData.ContainsKey("budget"));
        Assert.Null(model.TrialEndBehavior);
        Assert.False(model.RawData.ContainsKey("trialEndBehavior"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PlanRetrieveResponseDataDefaultTrialConfig
        {
            Duration = 0,
            Units = PlanRetrieveResponseDataDefaultTrialConfigUnits.Day,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PlanRetrieveResponseDataDefaultTrialConfig
        {
            Duration = 0,
            Units = PlanRetrieveResponseDataDefaultTrialConfigUnits.Day,

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
        var model = new PlanRetrieveResponseDataDefaultTrialConfig
        {
            Duration = 0,
            Units = PlanRetrieveResponseDataDefaultTrialConfigUnits.Day,

            Budget = null,
            TrialEndBehavior = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlanRetrieveResponseDataDefaultTrialConfig
        {
            Duration = 0,
            Units = PlanRetrieveResponseDataDefaultTrialConfigUnits.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior =
                PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
        };

        PlanRetrieveResponseDataDefaultTrialConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanRetrieveResponseDataDefaultTrialConfigUnitsTest : TestBase
{
    [Theory]
    [InlineData(PlanRetrieveResponseDataDefaultTrialConfigUnits.Day)]
    [InlineData(PlanRetrieveResponseDataDefaultTrialConfigUnits.Month)]
    public void Validation_Works(PlanRetrieveResponseDataDefaultTrialConfigUnits rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanRetrieveResponseDataDefaultTrialConfigUnits> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanRetrieveResponseDataDefaultTrialConfigUnits>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanRetrieveResponseDataDefaultTrialConfigUnits.Day)]
    [InlineData(PlanRetrieveResponseDataDefaultTrialConfigUnits.Month)]
    public void SerializationRoundtrip_Works(
        PlanRetrieveResponseDataDefaultTrialConfigUnits rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanRetrieveResponseDataDefaultTrialConfigUnits> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanRetrieveResponseDataDefaultTrialConfigUnits>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanRetrieveResponseDataDefaultTrialConfigUnits>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanRetrieveResponseDataDefaultTrialConfigUnits>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanRetrieveResponseDataDefaultTrialConfigBudgetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanRetrieveResponseDataDefaultTrialConfigBudget
        {
            HasSoftLimit = true,
            Limit = 0,
        };

        bool expectedHasSoftLimit = true;
        double expectedLimit = 0;

        Assert.Equal(expectedHasSoftLimit, model.HasSoftLimit);
        Assert.Equal(expectedLimit, model.Limit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanRetrieveResponseDataDefaultTrialConfigBudget
        {
            HasSoftLimit = true,
            Limit = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PlanRetrieveResponseDataDefaultTrialConfigBudget>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanRetrieveResponseDataDefaultTrialConfigBudget
        {
            HasSoftLimit = true,
            Limit = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<PlanRetrieveResponseDataDefaultTrialConfigBudget>(
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
        var model = new PlanRetrieveResponseDataDefaultTrialConfigBudget
        {
            HasSoftLimit = true,
            Limit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlanRetrieveResponseDataDefaultTrialConfigBudget
        {
            HasSoftLimit = true,
            Limit = 0,
        };

        PlanRetrieveResponseDataDefaultTrialConfigBudget copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehaviorTest : TestBase
{
    [Theory]
    [InlineData(PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior.ConvertToPaid)]
    [InlineData(PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior.CancelSubscription)]
    public void Validation_Works(
        PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior.ConvertToPaid)]
    [InlineData(PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior.CancelSubscription)]
    public void SerializationRoundtrip_Works(
        PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanRetrieveResponseDataDefaultTrialConfigTrialEndBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanRetrieveResponseDataEntitlementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanRetrieveResponseDataEntitlement
        {
            ID = "id",
            Type = PlanRetrieveResponseDataEntitlementType.Feature,
        };

        string expectedID = "id";
        ApiEnum<string, PlanRetrieveResponseDataEntitlementType> expectedType =
            PlanRetrieveResponseDataEntitlementType.Feature;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanRetrieveResponseDataEntitlement
        {
            ID = "id",
            Type = PlanRetrieveResponseDataEntitlementType.Feature,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanRetrieveResponseDataEntitlement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanRetrieveResponseDataEntitlement
        {
            ID = "id",
            Type = PlanRetrieveResponseDataEntitlementType.Feature,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanRetrieveResponseDataEntitlement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, PlanRetrieveResponseDataEntitlementType> expectedType =
            PlanRetrieveResponseDataEntitlementType.Feature;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanRetrieveResponseDataEntitlement
        {
            ID = "id",
            Type = PlanRetrieveResponseDataEntitlementType.Feature,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlanRetrieveResponseDataEntitlement
        {
            ID = "id",
            Type = PlanRetrieveResponseDataEntitlementType.Feature,
        };

        PlanRetrieveResponseDataEntitlement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanRetrieveResponseDataEntitlementTypeTest : TestBase
{
    [Theory]
    [InlineData(PlanRetrieveResponseDataEntitlementType.Feature)]
    [InlineData(PlanRetrieveResponseDataEntitlementType.Credit)]
    public void Validation_Works(PlanRetrieveResponseDataEntitlementType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanRetrieveResponseDataEntitlementType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanRetrieveResponseDataEntitlementType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanRetrieveResponseDataEntitlementType.Feature)]
    [InlineData(PlanRetrieveResponseDataEntitlementType.Credit)]
    public void SerializationRoundtrip_Works(PlanRetrieveResponseDataEntitlementType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanRetrieveResponseDataEntitlementType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanRetrieveResponseDataEntitlementType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanRetrieveResponseDataEntitlementType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanRetrieveResponseDataEntitlementType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanRetrieveResponseDataPricingTypeTest : TestBase
{
    [Theory]
    [InlineData(PlanRetrieveResponseDataPricingType.Free)]
    [InlineData(PlanRetrieveResponseDataPricingType.Paid)]
    [InlineData(PlanRetrieveResponseDataPricingType.Custom)]
    public void Validation_Works(PlanRetrieveResponseDataPricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanRetrieveResponseDataPricingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanRetrieveResponseDataPricingType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanRetrieveResponseDataPricingType.Free)]
    [InlineData(PlanRetrieveResponseDataPricingType.Paid)]
    [InlineData(PlanRetrieveResponseDataPricingType.Custom)]
    public void SerializationRoundtrip_Works(PlanRetrieveResponseDataPricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanRetrieveResponseDataPricingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanRetrieveResponseDataPricingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanRetrieveResponseDataPricingType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanRetrieveResponseDataPricingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanRetrieveResponseDataStatusTest : TestBase
{
    [Theory]
    [InlineData(PlanRetrieveResponseDataStatus.Draft)]
    [InlineData(PlanRetrieveResponseDataStatus.Published)]
    [InlineData(PlanRetrieveResponseDataStatus.Archived)]
    public void Validation_Works(PlanRetrieveResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanRetrieveResponseDataStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PlanRetrieveResponseDataStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanRetrieveResponseDataStatus.Draft)]
    [InlineData(PlanRetrieveResponseDataStatus.Published)]
    [InlineData(PlanRetrieveResponseDataStatus.Archived)]
    public void SerializationRoundtrip_Works(PlanRetrieveResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanRetrieveResponseDataStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanRetrieveResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PlanRetrieveResponseDataStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanRetrieveResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
