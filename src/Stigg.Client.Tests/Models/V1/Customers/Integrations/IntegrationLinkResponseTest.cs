using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Customers.Integrations;

namespace Stigg.Client.Tests.Models.V1.Customers.Integrations;

public class IntegrationLinkResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntegrationLinkResponse
        {
            Data = new()
            {
                ID = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = IntegrationLinkResponseDataVendorIdentifier.Auth0,
                SyncData = new IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData()
                {
                    BillingID = "billingId",
                    BillingLinkUrl = "billingLinkUrl",
                    PriceGroupPackageBillingID = "priceGroupPackageBillingId",
                },
            },
        };

        IntegrationLinkResponseData expectedData = new()
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationLinkResponseDataVendorIdentifier.Auth0,
            SyncData = new IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData()
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
        var model = new IntegrationLinkResponse
        {
            Data = new()
            {
                ID = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = IntegrationLinkResponseDataVendorIdentifier.Auth0,
                SyncData = new IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData()
                {
                    BillingID = "billingId",
                    BillingLinkUrl = "billingLinkUrl",
                    PriceGroupPackageBillingID = "priceGroupPackageBillingId",
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationLinkResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntegrationLinkResponse
        {
            Data = new()
            {
                ID = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = IntegrationLinkResponseDataVendorIdentifier.Auth0,
                SyncData = new IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData()
                {
                    BillingID = "billingId",
                    BillingLinkUrl = "billingLinkUrl",
                    PriceGroupPackageBillingID = "priceGroupPackageBillingId",
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationLinkResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        IntegrationLinkResponseData expectedData = new()
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationLinkResponseDataVendorIdentifier.Auth0,
            SyncData = new IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData()
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
        var model = new IntegrationLinkResponse
        {
            Data = new()
            {
                ID = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = IntegrationLinkResponseDataVendorIdentifier.Auth0,
                SyncData = new IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData()
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
        var model = new IntegrationLinkResponse
        {
            Data = new()
            {
                ID = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = IntegrationLinkResponseDataVendorIdentifier.Auth0,
                SyncData = new IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData()
                {
                    BillingID = "billingId",
                    BillingLinkUrl = "billingLinkUrl",
                    PriceGroupPackageBillingID = "priceGroupPackageBillingId",
                },
            },
        };

        IntegrationLinkResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IntegrationLinkResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntegrationLinkResponseData
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationLinkResponseDataVendorIdentifier.Auth0,
            SyncData = new IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData()
            {
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                PriceGroupPackageBillingID = "priceGroupPackageBillingId",
            },
        };

        string expectedID = "id";
        string expectedSyncedEntityID = "syncedEntityId";
        ApiEnum<string, IntegrationLinkResponseDataVendorIdentifier> expectedVendorIdentifier =
            IntegrationLinkResponseDataVendorIdentifier.Auth0;
        IntegrationLinkResponseDataSyncData expectedSyncData =
            new IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData()
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
        var model = new IntegrationLinkResponseData
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationLinkResponseDataVendorIdentifier.Auth0,
            SyncData = new IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData()
            {
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                PriceGroupPackageBillingID = "priceGroupPackageBillingId",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationLinkResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntegrationLinkResponseData
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationLinkResponseDataVendorIdentifier.Auth0,
            SyncData = new IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData()
            {
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                PriceGroupPackageBillingID = "priceGroupPackageBillingId",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationLinkResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedSyncedEntityID = "syncedEntityId";
        ApiEnum<string, IntegrationLinkResponseDataVendorIdentifier> expectedVendorIdentifier =
            IntegrationLinkResponseDataVendorIdentifier.Auth0;
        IntegrationLinkResponseDataSyncData expectedSyncData =
            new IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData()
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
        var model = new IntegrationLinkResponseData
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationLinkResponseDataVendorIdentifier.Auth0,
            SyncData = new IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData()
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
        var model = new IntegrationLinkResponseData
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationLinkResponseDataVendorIdentifier.Auth0,
        };

        Assert.Null(model.SyncData);
        Assert.False(model.RawData.ContainsKey("syncData"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new IntegrationLinkResponseData
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationLinkResponseDataVendorIdentifier.Auth0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new IntegrationLinkResponseData
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationLinkResponseDataVendorIdentifier.Auth0,

            SyncData = null,
        };

        Assert.Null(model.SyncData);
        Assert.True(model.RawData.ContainsKey("syncData"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new IntegrationLinkResponseData
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationLinkResponseDataVendorIdentifier.Auth0,

            SyncData = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IntegrationLinkResponseData
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationLinkResponseDataVendorIdentifier.Auth0,
            SyncData = new IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData()
            {
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                PriceGroupPackageBillingID = "priceGroupPackageBillingId",
            },
        };

        IntegrationLinkResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IntegrationLinkResponseDataVendorIdentifierTest : TestBase
{
    [Theory]
    [InlineData(IntegrationLinkResponseDataVendorIdentifier.Auth0)]
    [InlineData(IntegrationLinkResponseDataVendorIdentifier.Zuora)]
    [InlineData(IntegrationLinkResponseDataVendorIdentifier.Stripe)]
    [InlineData(IntegrationLinkResponseDataVendorIdentifier.Hubspot)]
    [InlineData(IntegrationLinkResponseDataVendorIdentifier.AwsMarketplace)]
    [InlineData(IntegrationLinkResponseDataVendorIdentifier.Snowflake)]
    [InlineData(IntegrationLinkResponseDataVendorIdentifier.Salesforce)]
    [InlineData(IntegrationLinkResponseDataVendorIdentifier.BigQuery)]
    [InlineData(IntegrationLinkResponseDataVendorIdentifier.OpenFga)]
    [InlineData(IntegrationLinkResponseDataVendorIdentifier.AppStore)]
    public void Validation_Works(IntegrationLinkResponseDataVendorIdentifier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntegrationLinkResponseDataVendorIdentifier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, IntegrationLinkResponseDataVendorIdentifier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(IntegrationLinkResponseDataVendorIdentifier.Auth0)]
    [InlineData(IntegrationLinkResponseDataVendorIdentifier.Zuora)]
    [InlineData(IntegrationLinkResponseDataVendorIdentifier.Stripe)]
    [InlineData(IntegrationLinkResponseDataVendorIdentifier.Hubspot)]
    [InlineData(IntegrationLinkResponseDataVendorIdentifier.AwsMarketplace)]
    [InlineData(IntegrationLinkResponseDataVendorIdentifier.Snowflake)]
    [InlineData(IntegrationLinkResponseDataVendorIdentifier.Salesforce)]
    [InlineData(IntegrationLinkResponseDataVendorIdentifier.BigQuery)]
    [InlineData(IntegrationLinkResponseDataVendorIdentifier.OpenFga)]
    [InlineData(IntegrationLinkResponseDataVendorIdentifier.AppStore)]
    public void SerializationRoundtrip_Works(IntegrationLinkResponseDataVendorIdentifier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntegrationLinkResponseDataVendorIdentifier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, IntegrationLinkResponseDataVendorIdentifier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, IntegrationLinkResponseDataVendorIdentifier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, IntegrationLinkResponseDataVendorIdentifier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class IntegrationLinkResponseDataSyncDataTest : TestBase
{
    [Fact]
    public void RevisionPriceBillingValidationWorks()
    {
        IntegrationLinkResponseDataSyncData value =
            new IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData()
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
        IntegrationLinkResponseDataSyncData value =
            new IntegrationLinkResponseDataSyncDataSyncRevisionBillingData()
            {
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
            };
        value.Validate();
    }

    [Fact]
    public void RevisionMarketplaceValidationWorks()
    {
        IntegrationLinkResponseDataSyncData value =
            new IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData("dimensions");
        value.Validate();
    }

    [Fact]
    public void RevisionPriceBillingSerializationRoundtripWorks()
    {
        IntegrationLinkResponseDataSyncData value =
            new IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData()
            {
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                PriceGroupPackageBillingID = "priceGroupPackageBillingId",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationLinkResponseDataSyncData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RevisionBillingSerializationRoundtripWorks()
    {
        IntegrationLinkResponseDataSyncData value =
            new IntegrationLinkResponseDataSyncDataSyncRevisionBillingData()
            {
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationLinkResponseDataSyncData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RevisionMarketplaceSerializationRoundtripWorks()
    {
        IntegrationLinkResponseDataSyncData value =
            new IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData("dimensions");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationLinkResponseDataSyncData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData
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
        var model = new IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            PriceGroupPackageBillingID = "priceGroupPackageBillingId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            PriceGroupPackageBillingID = "priceGroupPackageBillingId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData>(
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
        var model = new IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData
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
        var model = new IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            PriceGroupPackageBillingID = "priceGroupPackageBillingId",
        };

        IntegrationLinkResponseDataSyncDataSyncRevisionPriceBillingData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IntegrationLinkResponseDataSyncDataSyncRevisionBillingDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntegrationLinkResponseDataSyncDataSyncRevisionBillingData
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
        var model = new IntegrationLinkResponseDataSyncDataSyncRevisionBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<IntegrationLinkResponseDataSyncDataSyncRevisionBillingData>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntegrationLinkResponseDataSyncDataSyncRevisionBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<IntegrationLinkResponseDataSyncDataSyncRevisionBillingData>(
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
        var model = new IntegrationLinkResponseDataSyncDataSyncRevisionBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IntegrationLinkResponseDataSyncDataSyncRevisionBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
        };

        IntegrationLinkResponseDataSyncDataSyncRevisionBillingData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData
        {
            Dimensions = "dimensions",
        };

        string expectedDimensions = "dimensions";

        Assert.Equal(expectedDimensions, model.Dimensions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData
        {
            Dimensions = "dimensions",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData
        {
            Dimensions = "dimensions",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData>(
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
        var model = new IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData
        {
            Dimensions = "dimensions",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData
        {
            Dimensions = "dimensions",
        };

        IntegrationLinkResponseDataSyncDataSyncRevisionMarketplaceData copied = new(model);

        Assert.Equal(model, copied);
    }
}
