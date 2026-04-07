using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Customers.Integrations;

namespace Stigg.Client.Tests.Models.V1.Customers.Integrations;

public class IntegrationListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntegrationListResponse
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationListResponseVendorIdentifier.Auth0,
            SyncData = new SyncRevisionPriceBillingData()
            {
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                PriceGroupPackageBillingID = "priceGroupPackageBillingId",
            },
        };

        string expectedID = "id";
        string expectedSyncedEntityID = "syncedEntityId";
        ApiEnum<string, IntegrationListResponseVendorIdentifier> expectedVendorIdentifier =
            IntegrationListResponseVendorIdentifier.Auth0;
        SyncData expectedSyncData = new SyncRevisionPriceBillingData()
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            PriceGroupPackageBillingID = "priceGroupPackageBillingId",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedSyncedEntityID, model.SyncedEntityID);
        Assert.Equal(expectedVendorIdentifier, model.VendorIdentifier);
        Assert.Equal(expectedSyncData, model.SyncData);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IntegrationListResponse
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationListResponseVendorIdentifier.Auth0,
            SyncData = new SyncRevisionPriceBillingData()
            {
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                PriceGroupPackageBillingID = "priceGroupPackageBillingId",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntegrationListResponse
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationListResponseVendorIdentifier.Auth0,
            SyncData = new SyncRevisionPriceBillingData()
            {
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                PriceGroupPackageBillingID = "priceGroupPackageBillingId",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedSyncedEntityID = "syncedEntityId";
        ApiEnum<string, IntegrationListResponseVendorIdentifier> expectedVendorIdentifier =
            IntegrationListResponseVendorIdentifier.Auth0;
        SyncData expectedSyncData = new SyncRevisionPriceBillingData()
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            PriceGroupPackageBillingID = "priceGroupPackageBillingId",
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedSyncedEntityID, deserialized.SyncedEntityID);
        Assert.Equal(expectedVendorIdentifier, deserialized.VendorIdentifier);
        Assert.Equal(expectedSyncData, deserialized.SyncData);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IntegrationListResponse
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationListResponseVendorIdentifier.Auth0,
            SyncData = new SyncRevisionPriceBillingData()
            {
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                PriceGroupPackageBillingID = "priceGroupPackageBillingId",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new IntegrationListResponse
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationListResponseVendorIdentifier.Auth0,
        };

        Assert.Null(model.SyncData);
        Assert.False(model.RawData.ContainsKey("syncData"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new IntegrationListResponse
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationListResponseVendorIdentifier.Auth0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new IntegrationListResponse
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationListResponseVendorIdentifier.Auth0,

            SyncData = null,
        };

        Assert.Null(model.SyncData);
        Assert.True(model.RawData.ContainsKey("syncData"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new IntegrationListResponse
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationListResponseVendorIdentifier.Auth0,

            SyncData = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IntegrationListResponse
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationListResponseVendorIdentifier.Auth0,
            SyncData = new SyncRevisionPriceBillingData()
            {
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                PriceGroupPackageBillingID = "priceGroupPackageBillingId",
            },
        };

        IntegrationListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IntegrationListResponseVendorIdentifierTest : TestBase
{
    [Theory]
    [InlineData(IntegrationListResponseVendorIdentifier.Auth0)]
    [InlineData(IntegrationListResponseVendorIdentifier.Zuora)]
    [InlineData(IntegrationListResponseVendorIdentifier.Stripe)]
    [InlineData(IntegrationListResponseVendorIdentifier.Hubspot)]
    [InlineData(IntegrationListResponseVendorIdentifier.AwsMarketplace)]
    [InlineData(IntegrationListResponseVendorIdentifier.Snowflake)]
    [InlineData(IntegrationListResponseVendorIdentifier.Salesforce)]
    [InlineData(IntegrationListResponseVendorIdentifier.BigQuery)]
    [InlineData(IntegrationListResponseVendorIdentifier.OpenFga)]
    [InlineData(IntegrationListResponseVendorIdentifier.AppStore)]
    public void Validation_Works(IntegrationListResponseVendorIdentifier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntegrationListResponseVendorIdentifier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, IntegrationListResponseVendorIdentifier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(IntegrationListResponseVendorIdentifier.Auth0)]
    [InlineData(IntegrationListResponseVendorIdentifier.Zuora)]
    [InlineData(IntegrationListResponseVendorIdentifier.Stripe)]
    [InlineData(IntegrationListResponseVendorIdentifier.Hubspot)]
    [InlineData(IntegrationListResponseVendorIdentifier.AwsMarketplace)]
    [InlineData(IntegrationListResponseVendorIdentifier.Snowflake)]
    [InlineData(IntegrationListResponseVendorIdentifier.Salesforce)]
    [InlineData(IntegrationListResponseVendorIdentifier.BigQuery)]
    [InlineData(IntegrationListResponseVendorIdentifier.OpenFga)]
    [InlineData(IntegrationListResponseVendorIdentifier.AppStore)]
    public void SerializationRoundtrip_Works(IntegrationListResponseVendorIdentifier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntegrationListResponseVendorIdentifier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, IntegrationListResponseVendorIdentifier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, IntegrationListResponseVendorIdentifier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, IntegrationListResponseVendorIdentifier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SyncDataTest : TestBase
{
    [Fact]
    public void RevisionPriceBillingValidationWorks()
    {
        SyncData value = new SyncRevisionPriceBillingData()
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            PriceGroupPackageBillingID = "priceGroupPackageBillingId",
        };
        value.Validate();
    }

    [Fact]
    public void RevisionBillingValidationWorks()
    {
        SyncData value = new SyncRevisionBillingData()
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
        };
        value.Validate();
    }

    [Fact]
    public void RevisionMarketplaceValidationWorks()
    {
        SyncData value = new SyncRevisionMarketplaceData("dimensions");
        value.Validate();
    }

    [Fact]
    public void RevisionPriceBillingSerializationRoundtripWorks()
    {
        SyncData value = new SyncRevisionPriceBillingData()
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            PriceGroupPackageBillingID = "priceGroupPackageBillingId",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SyncData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RevisionBillingSerializationRoundtripWorks()
    {
        SyncData value = new SyncRevisionBillingData()
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SyncData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RevisionMarketplaceSerializationRoundtripWorks()
    {
        SyncData value = new SyncRevisionMarketplaceData("dimensions");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SyncData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SyncRevisionPriceBillingDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SyncRevisionPriceBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            PriceGroupPackageBillingID = "priceGroupPackageBillingId",
        };

        string expectedBillingID = "billingId";
        string expectedBillingLinkUrl = "billingLinkUrl";
        string expectedPriceGroupPackageBillingID = "priceGroupPackageBillingId";

        Assert.Equal(expectedBillingID, model.BillingID);
        Assert.Equal(expectedBillingLinkUrl, model.BillingLinkUrl);
        Assert.Equal(expectedPriceGroupPackageBillingID, model.PriceGroupPackageBillingID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SyncRevisionPriceBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            PriceGroupPackageBillingID = "priceGroupPackageBillingId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SyncRevisionPriceBillingData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SyncRevisionPriceBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            PriceGroupPackageBillingID = "priceGroupPackageBillingId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SyncRevisionPriceBillingData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBillingID = "billingId";
        string expectedBillingLinkUrl = "billingLinkUrl";
        string expectedPriceGroupPackageBillingID = "priceGroupPackageBillingId";

        Assert.Equal(expectedBillingID, deserialized.BillingID);
        Assert.Equal(expectedBillingLinkUrl, deserialized.BillingLinkUrl);
        Assert.Equal(expectedPriceGroupPackageBillingID, deserialized.PriceGroupPackageBillingID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SyncRevisionPriceBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            PriceGroupPackageBillingID = "priceGroupPackageBillingId",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SyncRevisionPriceBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            PriceGroupPackageBillingID = "priceGroupPackageBillingId",
        };

        SyncRevisionPriceBillingData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SyncRevisionBillingDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SyncRevisionBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
        };

        string expectedBillingID = "billingId";
        string expectedBillingLinkUrl = "billingLinkUrl";

        Assert.Equal(expectedBillingID, model.BillingID);
        Assert.Equal(expectedBillingLinkUrl, model.BillingLinkUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SyncRevisionBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SyncRevisionBillingData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SyncRevisionBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SyncRevisionBillingData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBillingID = "billingId";
        string expectedBillingLinkUrl = "billingLinkUrl";

        Assert.Equal(expectedBillingID, deserialized.BillingID);
        Assert.Equal(expectedBillingLinkUrl, deserialized.BillingLinkUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SyncRevisionBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SyncRevisionBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
        };

        SyncRevisionBillingData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SyncRevisionMarketplaceDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SyncRevisionMarketplaceData { Dimensions = "dimensions" };

        string expectedDimensions = "dimensions";

        Assert.Equal(expectedDimensions, model.Dimensions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SyncRevisionMarketplaceData { Dimensions = "dimensions" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SyncRevisionMarketplaceData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SyncRevisionMarketplaceData { Dimensions = "dimensions" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SyncRevisionMarketplaceData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDimensions = "dimensions";

        Assert.Equal(expectedDimensions, deserialized.Dimensions);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SyncRevisionMarketplaceData { Dimensions = "dimensions" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SyncRevisionMarketplaceData { Dimensions = "dimensions" };

        SyncRevisionMarketplaceData copied = new(model);

        Assert.Equal(model, copied);
    }
}
