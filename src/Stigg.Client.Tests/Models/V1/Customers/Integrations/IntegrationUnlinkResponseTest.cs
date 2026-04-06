using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Customers.Integrations;

namespace Stigg.Client.Tests.Models.V1.Customers.Integrations;

public class IntegrationUnlinkResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntegrationUnlinkResponse
        {
            Data = new()
            {
                ID = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = IntegrationUnlinkResponseDataVendorIdentifier.Auth0,
                SyncData = new IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData()
                {
                    BillingID = "billingId",
                    BillingLinkUrl = "billingLinkUrl",
                    PriceGroupPackageBillingID = "priceGroupPackageBillingId",
                },
            },
        };

        IntegrationUnlinkResponseData expectedData = new()
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationUnlinkResponseDataVendorIdentifier.Auth0,
            SyncData = new IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData()
            {
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                PriceGroupPackageBillingID = "priceGroupPackageBillingId",
            },
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IntegrationUnlinkResponse
        {
            Data = new()
            {
                ID = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = IntegrationUnlinkResponseDataVendorIdentifier.Auth0,
                SyncData = new IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData()
                {
                    BillingID = "billingId",
                    BillingLinkUrl = "billingLinkUrl",
                    PriceGroupPackageBillingID = "priceGroupPackageBillingId",
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationUnlinkResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntegrationUnlinkResponse
        {
            Data = new()
            {
                ID = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = IntegrationUnlinkResponseDataVendorIdentifier.Auth0,
                SyncData = new IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData()
                {
                    BillingID = "billingId",
                    BillingLinkUrl = "billingLinkUrl",
                    PriceGroupPackageBillingID = "priceGroupPackageBillingId",
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationUnlinkResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        IntegrationUnlinkResponseData expectedData = new()
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationUnlinkResponseDataVendorIdentifier.Auth0,
            SyncData = new IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData()
            {
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                PriceGroupPackageBillingID = "priceGroupPackageBillingId",
            },
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IntegrationUnlinkResponse
        {
            Data = new()
            {
                ID = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = IntegrationUnlinkResponseDataVendorIdentifier.Auth0,
                SyncData = new IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData()
                {
                    BillingID = "billingId",
                    BillingLinkUrl = "billingLinkUrl",
                    PriceGroupPackageBillingID = "priceGroupPackageBillingId",
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IntegrationUnlinkResponse
        {
            Data = new()
            {
                ID = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = IntegrationUnlinkResponseDataVendorIdentifier.Auth0,
                SyncData = new IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData()
                {
                    BillingID = "billingId",
                    BillingLinkUrl = "billingLinkUrl",
                    PriceGroupPackageBillingID = "priceGroupPackageBillingId",
                },
            },
        };

        IntegrationUnlinkResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IntegrationUnlinkResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntegrationUnlinkResponseData
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationUnlinkResponseDataVendorIdentifier.Auth0,
            SyncData = new IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData()
            {
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                PriceGroupPackageBillingID = "priceGroupPackageBillingId",
            },
        };

        string expectedID = "id";
        string expectedSyncedEntityID = "syncedEntityId";
        ApiEnum<string, IntegrationUnlinkResponseDataVendorIdentifier> expectedVendorIdentifier =
            IntegrationUnlinkResponseDataVendorIdentifier.Auth0;
        IntegrationUnlinkResponseDataSyncData expectedSyncData =
            new IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData()
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
        var model = new IntegrationUnlinkResponseData
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationUnlinkResponseDataVendorIdentifier.Auth0,
            SyncData = new IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData()
            {
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                PriceGroupPackageBillingID = "priceGroupPackageBillingId",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationUnlinkResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntegrationUnlinkResponseData
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationUnlinkResponseDataVendorIdentifier.Auth0,
            SyncData = new IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData()
            {
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                PriceGroupPackageBillingID = "priceGroupPackageBillingId",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationUnlinkResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedSyncedEntityID = "syncedEntityId";
        ApiEnum<string, IntegrationUnlinkResponseDataVendorIdentifier> expectedVendorIdentifier =
            IntegrationUnlinkResponseDataVendorIdentifier.Auth0;
        IntegrationUnlinkResponseDataSyncData expectedSyncData =
            new IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData()
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
        var model = new IntegrationUnlinkResponseData
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationUnlinkResponseDataVendorIdentifier.Auth0,
            SyncData = new IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData()
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
        var model = new IntegrationUnlinkResponseData
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationUnlinkResponseDataVendorIdentifier.Auth0,
        };

        Assert.Null(model.SyncData);
        Assert.False(model.RawData.ContainsKey("syncData"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new IntegrationUnlinkResponseData
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationUnlinkResponseDataVendorIdentifier.Auth0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new IntegrationUnlinkResponseData
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationUnlinkResponseDataVendorIdentifier.Auth0,

            SyncData = null,
        };

        Assert.Null(model.SyncData);
        Assert.True(model.RawData.ContainsKey("syncData"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new IntegrationUnlinkResponseData
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationUnlinkResponseDataVendorIdentifier.Auth0,

            SyncData = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IntegrationUnlinkResponseData
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationUnlinkResponseDataVendorIdentifier.Auth0,
            SyncData = new IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData()
            {
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                PriceGroupPackageBillingID = "priceGroupPackageBillingId",
            },
        };

        IntegrationUnlinkResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IntegrationUnlinkResponseDataVendorIdentifierTest : TestBase
{
    [Theory]
    [InlineData(IntegrationUnlinkResponseDataVendorIdentifier.Auth0)]
    [InlineData(IntegrationUnlinkResponseDataVendorIdentifier.Zuora)]
    [InlineData(IntegrationUnlinkResponseDataVendorIdentifier.Stripe)]
    [InlineData(IntegrationUnlinkResponseDataVendorIdentifier.Hubspot)]
    [InlineData(IntegrationUnlinkResponseDataVendorIdentifier.AwsMarketplace)]
    [InlineData(IntegrationUnlinkResponseDataVendorIdentifier.Snowflake)]
    [InlineData(IntegrationUnlinkResponseDataVendorIdentifier.Salesforce)]
    [InlineData(IntegrationUnlinkResponseDataVendorIdentifier.BigQuery)]
    [InlineData(IntegrationUnlinkResponseDataVendorIdentifier.OpenFga)]
    [InlineData(IntegrationUnlinkResponseDataVendorIdentifier.AppStore)]
    public void Validation_Works(IntegrationUnlinkResponseDataVendorIdentifier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntegrationUnlinkResponseDataVendorIdentifier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, IntegrationUnlinkResponseDataVendorIdentifier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(IntegrationUnlinkResponseDataVendorIdentifier.Auth0)]
    [InlineData(IntegrationUnlinkResponseDataVendorIdentifier.Zuora)]
    [InlineData(IntegrationUnlinkResponseDataVendorIdentifier.Stripe)]
    [InlineData(IntegrationUnlinkResponseDataVendorIdentifier.Hubspot)]
    [InlineData(IntegrationUnlinkResponseDataVendorIdentifier.AwsMarketplace)]
    [InlineData(IntegrationUnlinkResponseDataVendorIdentifier.Snowflake)]
    [InlineData(IntegrationUnlinkResponseDataVendorIdentifier.Salesforce)]
    [InlineData(IntegrationUnlinkResponseDataVendorIdentifier.BigQuery)]
    [InlineData(IntegrationUnlinkResponseDataVendorIdentifier.OpenFga)]
    [InlineData(IntegrationUnlinkResponseDataVendorIdentifier.AppStore)]
    public void SerializationRoundtrip_Works(IntegrationUnlinkResponseDataVendorIdentifier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntegrationUnlinkResponseDataVendorIdentifier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, IntegrationUnlinkResponseDataVendorIdentifier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, IntegrationUnlinkResponseDataVendorIdentifier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, IntegrationUnlinkResponseDataVendorIdentifier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class IntegrationUnlinkResponseDataSyncDataTest : TestBase
{
    [Fact]
    public void RevisionPriceBillingValidationWorks()
    {
        IntegrationUnlinkResponseDataSyncData value =
            new IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData()
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
        IntegrationUnlinkResponseDataSyncData value =
            new IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData()
            {
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
            };
        value.Validate();
    }

    [Fact]
    public void RevisionMarketplaceValidationWorks()
    {
        IntegrationUnlinkResponseDataSyncData value =
            new IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData("dimensions");
        value.Validate();
    }

    [Fact]
    public void RevisionPriceBillingSerializationRoundtripWorks()
    {
        IntegrationUnlinkResponseDataSyncData value =
            new IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData()
            {
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                PriceGroupPackageBillingID = "priceGroupPackageBillingId",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationUnlinkResponseDataSyncData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RevisionBillingSerializationRoundtripWorks()
    {
        IntegrationUnlinkResponseDataSyncData value =
            new IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData()
            {
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationUnlinkResponseDataSyncData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RevisionMarketplaceSerializationRoundtripWorks()
    {
        IntegrationUnlinkResponseDataSyncData value =
            new IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData("dimensions");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationUnlinkResponseDataSyncData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData
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
        var model = new IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            PriceGroupPackageBillingID = "priceGroupPackageBillingId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            PriceGroupPackageBillingID = "priceGroupPackageBillingId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData>(
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
        var model = new IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData
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
        var model = new IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            PriceGroupPackageBillingID = "priceGroupPackageBillingId",
        };

        IntegrationUnlinkResponseDataSyncDataSyncRevisionPriceBillingData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData
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
        var model = new IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData>(
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
        var model = new IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
        };

        IntegrationUnlinkResponseDataSyncDataSyncRevisionBillingData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData
        {
            Dimensions = "dimensions",
        };

        string expectedDimensions = "dimensions";

        Assert.Equal(expectedDimensions, model.Dimensions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData
        {
            Dimensions = "dimensions",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData
        {
            Dimensions = "dimensions",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData>(
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
        var model = new IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData
        {
            Dimensions = "dimensions",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData
        {
            Dimensions = "dimensions",
        };

        IntegrationUnlinkResponseDataSyncDataSyncRevisionMarketplaceData copied = new(model);

        Assert.Equal(model, copied);
    }
}
