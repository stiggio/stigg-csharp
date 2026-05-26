using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Addons;

namespace Stigg.Client.Tests.Models.V1.Addons;

public class AddonListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddonListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Dependencies = ["string"],
                    Description = "description",
                    DisplayName = "displayName",
                    Entitlements =
                    [
                        new() { ID = "id", Type = AddonListResponseEntitlementType.Feature },
                    ],
                    IsLatest = true,
                    MaxQuantity = 0,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PricingType = AddonListResponsePricingType.Free,
                    ProductID = "productId",
                    Status = AddonListResponseStatus.Draft,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    VersionNumber = 0,
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        List<AddonListResponse> expectedData =
        [
            new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Dependencies = ["string"],
                Description = "description",
                DisplayName = "displayName",
                Entitlements =
                [
                    new() { ID = "id", Type = AddonListResponseEntitlementType.Feature },
                ],
                IsLatest = true,
                MaxQuantity = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PricingType = AddonListResponsePricingType.Free,
                ProductID = "productId",
                Status = AddonListResponseStatus.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        ];
        AddonListPageResponsePagination expectedPagination = new()
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
        var model = new AddonListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Dependencies = ["string"],
                    Description = "description",
                    DisplayName = "displayName",
                    Entitlements =
                    [
                        new() { ID = "id", Type = AddonListResponseEntitlementType.Feature },
                    ],
                    IsLatest = true,
                    MaxQuantity = 0,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PricingType = AddonListResponsePricingType.Free,
                    ProductID = "productId",
                    Status = AddonListResponseStatus.Draft,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    VersionNumber = 0,
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddonListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Dependencies = ["string"],
                    Description = "description",
                    DisplayName = "displayName",
                    Entitlements =
                    [
                        new() { ID = "id", Type = AddonListResponseEntitlementType.Feature },
                    ],
                    IsLatest = true,
                    MaxQuantity = 0,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PricingType = AddonListResponsePricingType.Free,
                    ProductID = "productId",
                    Status = AddonListResponseStatus.Draft,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    VersionNumber = 0,
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<AddonListResponse> expectedData =
        [
            new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Dependencies = ["string"],
                Description = "description",
                DisplayName = "displayName",
                Entitlements =
                [
                    new() { ID = "id", Type = AddonListResponseEntitlementType.Feature },
                ],
                IsLatest = true,
                MaxQuantity = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PricingType = AddonListResponsePricingType.Free,
                ProductID = "productId",
                Status = AddonListResponseStatus.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        ];
        AddonListPageResponsePagination expectedPagination = new()
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
        var model = new AddonListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Dependencies = ["string"],
                    Description = "description",
                    DisplayName = "displayName",
                    Entitlements =
                    [
                        new() { ID = "id", Type = AddonListResponseEntitlementType.Feature },
                    ],
                    IsLatest = true,
                    MaxQuantity = 0,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PricingType = AddonListResponsePricingType.Free,
                    ProductID = "productId",
                    Status = AddonListResponseStatus.Draft,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    VersionNumber = 0,
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
        var model = new AddonListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Dependencies = ["string"],
                    Description = "description",
                    DisplayName = "displayName",
                    Entitlements =
                    [
                        new() { ID = "id", Type = AddonListResponseEntitlementType.Feature },
                    ],
                    IsLatest = true,
                    MaxQuantity = 0,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PricingType = AddonListResponsePricingType.Free,
                    ProductID = "productId",
                    Status = AddonListResponseStatus.Draft,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    VersionNumber = 0,
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        AddonListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddonListPageResponsePaginationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddonListPageResponsePagination
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
        var model = new AddonListPageResponsePagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonListPageResponsePagination>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddonListPageResponsePagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonListPageResponsePagination>(
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
        var model = new AddonListPageResponsePagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AddonListPageResponsePagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        AddonListPageResponsePagination copied = new(model);

        Assert.Equal(model, copied);
    }
}
