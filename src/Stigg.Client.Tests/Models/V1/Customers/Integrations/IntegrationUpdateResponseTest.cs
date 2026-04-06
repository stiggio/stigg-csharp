using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Customers.Integrations;

namespace Stigg.Client.Tests.Models.V1.Customers.Integrations;

public class IntegrationUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntegrationUpdateResponse
        {
            Data = new()
            {
                ID = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = IntegrationUpdateResponseDataVendorIdentifier.Auth0,
                SyncData = new IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData()
                {
                    BillingID = "billingId",
                    BillingLinkUrl = "billingLinkUrl",
                    PriceGroupPackageBillingID = "priceGroupPackageBillingId",
                },
            },
        };

        IntegrationUpdateResponseData expectedData = new()
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationUpdateResponseDataVendorIdentifier.Auth0,
            SyncData = new IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData()
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
        var model = new IntegrationUpdateResponse
        {
            Data = new()
            {
                ID = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = IntegrationUpdateResponseDataVendorIdentifier.Auth0,
                SyncData = new IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData()
                {
                    BillingID = "billingId",
                    BillingLinkUrl = "billingLinkUrl",
                    PriceGroupPackageBillingID = "priceGroupPackageBillingId",
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntegrationUpdateResponse
        {
            Data = new()
            {
                ID = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = IntegrationUpdateResponseDataVendorIdentifier.Auth0,
                SyncData = new IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData()
                {
                    BillingID = "billingId",
                    BillingLinkUrl = "billingLinkUrl",
                    PriceGroupPackageBillingID = "priceGroupPackageBillingId",
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        IntegrationUpdateResponseData expectedData = new()
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationUpdateResponseDataVendorIdentifier.Auth0,
            SyncData = new IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData()
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
        var model = new IntegrationUpdateResponse
        {
            Data = new()
            {
                ID = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = IntegrationUpdateResponseDataVendorIdentifier.Auth0,
                SyncData = new IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData()
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
        var model = new IntegrationUpdateResponse
        {
            Data = new()
            {
                ID = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = IntegrationUpdateResponseDataVendorIdentifier.Auth0,
                SyncData = new IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData()
                {
                    BillingID = "billingId",
                    BillingLinkUrl = "billingLinkUrl",
                    PriceGroupPackageBillingID = "priceGroupPackageBillingId",
                },
            },
        };

        IntegrationUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IntegrationUpdateResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntegrationUpdateResponseData
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationUpdateResponseDataVendorIdentifier.Auth0,
            SyncData = new IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData()
            {
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                PriceGroupPackageBillingID = "priceGroupPackageBillingId",
            },
        };

        string expectedID = "id";
        string expectedSyncedEntityID = "syncedEntityId";
        ApiEnum<string, IntegrationUpdateResponseDataVendorIdentifier> expectedVendorIdentifier =
            IntegrationUpdateResponseDataVendorIdentifier.Auth0;
        IntegrationUpdateResponseDataSyncData expectedSyncData =
            new IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData()
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
        var model = new IntegrationUpdateResponseData
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationUpdateResponseDataVendorIdentifier.Auth0,
            SyncData = new IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData()
            {
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                PriceGroupPackageBillingID = "priceGroupPackageBillingId",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationUpdateResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntegrationUpdateResponseData
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationUpdateResponseDataVendorIdentifier.Auth0,
            SyncData = new IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData()
            {
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                PriceGroupPackageBillingID = "priceGroupPackageBillingId",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationUpdateResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedSyncedEntityID = "syncedEntityId";
        ApiEnum<string, IntegrationUpdateResponseDataVendorIdentifier> expectedVendorIdentifier =
            IntegrationUpdateResponseDataVendorIdentifier.Auth0;
        IntegrationUpdateResponseDataSyncData expectedSyncData =
            new IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData()
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
        var model = new IntegrationUpdateResponseData
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationUpdateResponseDataVendorIdentifier.Auth0,
            SyncData = new IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData()
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
        var model = new IntegrationUpdateResponseData
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationUpdateResponseDataVendorIdentifier.Auth0,
        };

        Assert.Null(model.SyncData);
        Assert.False(model.RawData.ContainsKey("syncData"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new IntegrationUpdateResponseData
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationUpdateResponseDataVendorIdentifier.Auth0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new IntegrationUpdateResponseData
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationUpdateResponseDataVendorIdentifier.Auth0,

            SyncData = null,
        };

        Assert.Null(model.SyncData);
        Assert.True(model.RawData.ContainsKey("syncData"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new IntegrationUpdateResponseData
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationUpdateResponseDataVendorIdentifier.Auth0,

            SyncData = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IntegrationUpdateResponseData
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationUpdateResponseDataVendorIdentifier.Auth0,
            SyncData = new IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData()
            {
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                PriceGroupPackageBillingID = "priceGroupPackageBillingId",
            },
        };

        IntegrationUpdateResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IntegrationUpdateResponseDataVendorIdentifierTest : TestBase
{
    [Theory]
    [InlineData(IntegrationUpdateResponseDataVendorIdentifier.Auth0)]
    [InlineData(IntegrationUpdateResponseDataVendorIdentifier.Zuora)]
    [InlineData(IntegrationUpdateResponseDataVendorIdentifier.Stripe)]
    [InlineData(IntegrationUpdateResponseDataVendorIdentifier.Hubspot)]
    [InlineData(IntegrationUpdateResponseDataVendorIdentifier.AwsMarketplace)]
    [InlineData(IntegrationUpdateResponseDataVendorIdentifier.Snowflake)]
    [InlineData(IntegrationUpdateResponseDataVendorIdentifier.Salesforce)]
    [InlineData(IntegrationUpdateResponseDataVendorIdentifier.BigQuery)]
    [InlineData(IntegrationUpdateResponseDataVendorIdentifier.OpenFga)]
    [InlineData(IntegrationUpdateResponseDataVendorIdentifier.AppStore)]
    public void Validation_Works(IntegrationUpdateResponseDataVendorIdentifier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntegrationUpdateResponseDataVendorIdentifier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, IntegrationUpdateResponseDataVendorIdentifier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(IntegrationUpdateResponseDataVendorIdentifier.Auth0)]
    [InlineData(IntegrationUpdateResponseDataVendorIdentifier.Zuora)]
    [InlineData(IntegrationUpdateResponseDataVendorIdentifier.Stripe)]
    [InlineData(IntegrationUpdateResponseDataVendorIdentifier.Hubspot)]
    [InlineData(IntegrationUpdateResponseDataVendorIdentifier.AwsMarketplace)]
    [InlineData(IntegrationUpdateResponseDataVendorIdentifier.Snowflake)]
    [InlineData(IntegrationUpdateResponseDataVendorIdentifier.Salesforce)]
    [InlineData(IntegrationUpdateResponseDataVendorIdentifier.BigQuery)]
    [InlineData(IntegrationUpdateResponseDataVendorIdentifier.OpenFga)]
    [InlineData(IntegrationUpdateResponseDataVendorIdentifier.AppStore)]
    public void SerializationRoundtrip_Works(IntegrationUpdateResponseDataVendorIdentifier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntegrationUpdateResponseDataVendorIdentifier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, IntegrationUpdateResponseDataVendorIdentifier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, IntegrationUpdateResponseDataVendorIdentifier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, IntegrationUpdateResponseDataVendorIdentifier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class IntegrationUpdateResponseDataSyncDataTest : TestBase
{
    [Fact]
    public void RevisionPriceBillingValidationWorks()
    {
        IntegrationUpdateResponseDataSyncData value =
            new IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData()
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
        IntegrationUpdateResponseDataSyncData value =
            new IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData()
            {
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
            };
        value.Validate();
    }

    [Fact]
    public void RevisionMarketplaceValidationWorks()
    {
        IntegrationUpdateResponseDataSyncData value =
            new IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData("dimensions");
        value.Validate();
    }

    [Fact]
    public void RevisionPriceBillingSerializationRoundtripWorks()
    {
        IntegrationUpdateResponseDataSyncData value =
            new IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData()
            {
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                PriceGroupPackageBillingID = "priceGroupPackageBillingId",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationUpdateResponseDataSyncData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RevisionBillingSerializationRoundtripWorks()
    {
        IntegrationUpdateResponseDataSyncData value =
            new IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData()
            {
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
            };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationUpdateResponseDataSyncData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void RevisionMarketplaceSerializationRoundtripWorks()
    {
        IntegrationUpdateResponseDataSyncData value =
            new IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData("dimensions");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationUpdateResponseDataSyncData>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData
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
        var model = new IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            PriceGroupPackageBillingID = "priceGroupPackageBillingId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            PriceGroupPackageBillingID = "priceGroupPackageBillingId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData>(
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
        var model = new IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData
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
        var model = new IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            PriceGroupPackageBillingID = "priceGroupPackageBillingId",
        };

        IntegrationUpdateResponseDataSyncDataSyncRevisionPriceBillingData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IntegrationUpdateResponseDataSyncDataSyncRevisionBillingDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData
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
        var model = new IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData>(
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
        var model = new IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData
        {
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
        };

        IntegrationUpdateResponseDataSyncDataSyncRevisionBillingData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData
        {
            Dimensions = "dimensions",
        };

        string expectedDimensions = "dimensions";

        Assert.Equal(expectedDimensions, model.Dimensions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData
        {
            Dimensions = "dimensions",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData
        {
            Dimensions = "dimensions",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData>(
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
        var model = new IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData
        {
            Dimensions = "dimensions",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData
        {
            Dimensions = "dimensions",
        };

        IntegrationUpdateResponseDataSyncDataSyncRevisionMarketplaceData copied = new(model);

        Assert.Equal(model, copied);
    }
}
