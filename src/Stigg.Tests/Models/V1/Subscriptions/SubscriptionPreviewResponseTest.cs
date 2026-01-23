using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Core;
using Stigg.Models.V1.Subscriptions;

namespace Stigg.Tests.Models.V1.Subscriptions;

public class SubscriptionPreviewResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionPreviewResponse
        {
            Data = new()
            {
                ImmediateInvoice = new()
                {
                    SubTotal = 0,
                    Total = 0,
                    BillingPeriodRange = new()
                    {
                        End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    Currency = "currency",
                    Discount = 0,
                    DiscountDetails = new()
                    {
                        Code = "code",
                        FixedAmount = 0,
                        Percentage = 0,
                    },
                    Discounts =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency = "currency",
                            Description = "description",
                        },
                    ],
                    Lines =
                    [
                        new()
                        {
                            Currency = "currency",
                            Description = "description",
                            SubTotal = 0,
                            UnitPrice = 0,
                            Quantity = 0,
                        },
                    ],
                    Tax = 0,
                },
                BillingPeriodRange = new()
                {
                    End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                FreeItems = [new() { AddonID = "addonId", Quantity = 0 }],
                HasScheduledUpdates = true,
                IsPlanDowngrade = true,
                RecurringInvoice = new()
                {
                    SubTotal = 0,
                    Total = 0,
                    BillingPeriodRange = new()
                    {
                        End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    Currency = "currency",
                    Discount = 0,
                    DiscountDetails = new()
                    {
                        Code = "code",
                        FixedAmount = 0,
                        Percentage = 0,
                    },
                    Discounts =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency = "currency",
                            Description = "description",
                        },
                    ],
                    Lines =
                    [
                        new()
                        {
                            Currency = "currency",
                            Description = "description",
                            SubTotal = 0,
                            UnitPrice = 0,
                            Quantity = 0,
                        },
                    ],
                    Tax = 0,
                },
            },
        };

        SubscriptionPreviewResponseData expectedData = new()
        {
            ImmediateInvoice = new()
            {
                SubTotal = 0,
                Total = 0,
                BillingPeriodRange = new()
                {
                    End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Currency = "currency",
                Discount = 0,
                DiscountDetails = new()
                {
                    Code = "code",
                    FixedAmount = 0,
                    Percentage = 0,
                },
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        Currency = "currency",
                        Description = "description",
                    },
                ],
                Lines =
                [
                    new()
                    {
                        Currency = "currency",
                        Description = "description",
                        SubTotal = 0,
                        UnitPrice = 0,
                        Quantity = 0,
                    },
                ],
                Tax = 0,
            },
            BillingPeriodRange = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            FreeItems = [new() { AddonID = "addonId", Quantity = 0 }],
            HasScheduledUpdates = true,
            IsPlanDowngrade = true,
            RecurringInvoice = new()
            {
                SubTotal = 0,
                Total = 0,
                BillingPeriodRange = new()
                {
                    End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Currency = "currency",
                Discount = 0,
                DiscountDetails = new()
                {
                    Code = "code",
                    FixedAmount = 0,
                    Percentage = 0,
                },
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        Currency = "currency",
                        Description = "description",
                    },
                ],
                Lines =
                [
                    new()
                    {
                        Currency = "currency",
                        Description = "description",
                        SubTotal = 0,
                        UnitPrice = 0,
                        Quantity = 0,
                    },
                ],
                Tax = 0,
            },
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionPreviewResponse
        {
            Data = new()
            {
                ImmediateInvoice = new()
                {
                    SubTotal = 0,
                    Total = 0,
                    BillingPeriodRange = new()
                    {
                        End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    Currency = "currency",
                    Discount = 0,
                    DiscountDetails = new()
                    {
                        Code = "code",
                        FixedAmount = 0,
                        Percentage = 0,
                    },
                    Discounts =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency = "currency",
                            Description = "description",
                        },
                    ],
                    Lines =
                    [
                        new()
                        {
                            Currency = "currency",
                            Description = "description",
                            SubTotal = 0,
                            UnitPrice = 0,
                            Quantity = 0,
                        },
                    ],
                    Tax = 0,
                },
                BillingPeriodRange = new()
                {
                    End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                FreeItems = [new() { AddonID = "addonId", Quantity = 0 }],
                HasScheduledUpdates = true,
                IsPlanDowngrade = true,
                RecurringInvoice = new()
                {
                    SubTotal = 0,
                    Total = 0,
                    BillingPeriodRange = new()
                    {
                        End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    Currency = "currency",
                    Discount = 0,
                    DiscountDetails = new()
                    {
                        Code = "code",
                        FixedAmount = 0,
                        Percentage = 0,
                    },
                    Discounts =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency = "currency",
                            Description = "description",
                        },
                    ],
                    Lines =
                    [
                        new()
                        {
                            Currency = "currency",
                            Description = "description",
                            SubTotal = 0,
                            UnitPrice = 0,
                            Quantity = 0,
                        },
                    ],
                    Tax = 0,
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionPreviewResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionPreviewResponse
        {
            Data = new()
            {
                ImmediateInvoice = new()
                {
                    SubTotal = 0,
                    Total = 0,
                    BillingPeriodRange = new()
                    {
                        End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    Currency = "currency",
                    Discount = 0,
                    DiscountDetails = new()
                    {
                        Code = "code",
                        FixedAmount = 0,
                        Percentage = 0,
                    },
                    Discounts =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency = "currency",
                            Description = "description",
                        },
                    ],
                    Lines =
                    [
                        new()
                        {
                            Currency = "currency",
                            Description = "description",
                            SubTotal = 0,
                            UnitPrice = 0,
                            Quantity = 0,
                        },
                    ],
                    Tax = 0,
                },
                BillingPeriodRange = new()
                {
                    End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                FreeItems = [new() { AddonID = "addonId", Quantity = 0 }],
                HasScheduledUpdates = true,
                IsPlanDowngrade = true,
                RecurringInvoice = new()
                {
                    SubTotal = 0,
                    Total = 0,
                    BillingPeriodRange = new()
                    {
                        End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    Currency = "currency",
                    Discount = 0,
                    DiscountDetails = new()
                    {
                        Code = "code",
                        FixedAmount = 0,
                        Percentage = 0,
                    },
                    Discounts =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency = "currency",
                            Description = "description",
                        },
                    ],
                    Lines =
                    [
                        new()
                        {
                            Currency = "currency",
                            Description = "description",
                            SubTotal = 0,
                            UnitPrice = 0,
                            Quantity = 0,
                        },
                    ],
                    Tax = 0,
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionPreviewResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        SubscriptionPreviewResponseData expectedData = new()
        {
            ImmediateInvoice = new()
            {
                SubTotal = 0,
                Total = 0,
                BillingPeriodRange = new()
                {
                    End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Currency = "currency",
                Discount = 0,
                DiscountDetails = new()
                {
                    Code = "code",
                    FixedAmount = 0,
                    Percentage = 0,
                },
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        Currency = "currency",
                        Description = "description",
                    },
                ],
                Lines =
                [
                    new()
                    {
                        Currency = "currency",
                        Description = "description",
                        SubTotal = 0,
                        UnitPrice = 0,
                        Quantity = 0,
                    },
                ],
                Tax = 0,
            },
            BillingPeriodRange = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            FreeItems = [new() { AddonID = "addonId", Quantity = 0 }],
            HasScheduledUpdates = true,
            IsPlanDowngrade = true,
            RecurringInvoice = new()
            {
                SubTotal = 0,
                Total = 0,
                BillingPeriodRange = new()
                {
                    End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Currency = "currency",
                Discount = 0,
                DiscountDetails = new()
                {
                    Code = "code",
                    FixedAmount = 0,
                    Percentage = 0,
                },
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        Currency = "currency",
                        Description = "description",
                    },
                ],
                Lines =
                [
                    new()
                    {
                        Currency = "currency",
                        Description = "description",
                        SubTotal = 0,
                        UnitPrice = 0,
                        Quantity = 0,
                    },
                ],
                Tax = 0,
            },
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionPreviewResponse
        {
            Data = new()
            {
                ImmediateInvoice = new()
                {
                    SubTotal = 0,
                    Total = 0,
                    BillingPeriodRange = new()
                    {
                        End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    Currency = "currency",
                    Discount = 0,
                    DiscountDetails = new()
                    {
                        Code = "code",
                        FixedAmount = 0,
                        Percentage = 0,
                    },
                    Discounts =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency = "currency",
                            Description = "description",
                        },
                    ],
                    Lines =
                    [
                        new()
                        {
                            Currency = "currency",
                            Description = "description",
                            SubTotal = 0,
                            UnitPrice = 0,
                            Quantity = 0,
                        },
                    ],
                    Tax = 0,
                },
                BillingPeriodRange = new()
                {
                    End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                FreeItems = [new() { AddonID = "addonId", Quantity = 0 }],
                HasScheduledUpdates = true,
                IsPlanDowngrade = true,
                RecurringInvoice = new()
                {
                    SubTotal = 0,
                    Total = 0,
                    BillingPeriodRange = new()
                    {
                        End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    Currency = "currency",
                    Discount = 0,
                    DiscountDetails = new()
                    {
                        Code = "code",
                        FixedAmount = 0,
                        Percentage = 0,
                    },
                    Discounts =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency = "currency",
                            Description = "description",
                        },
                    ],
                    Lines =
                    [
                        new()
                        {
                            Currency = "currency",
                            Description = "description",
                            SubTotal = 0,
                            UnitPrice = 0,
                            Quantity = 0,
                        },
                    ],
                    Tax = 0,
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionPreviewResponse
        {
            Data = new()
            {
                ImmediateInvoice = new()
                {
                    SubTotal = 0,
                    Total = 0,
                    BillingPeriodRange = new()
                    {
                        End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    Currency = "currency",
                    Discount = 0,
                    DiscountDetails = new()
                    {
                        Code = "code",
                        FixedAmount = 0,
                        Percentage = 0,
                    },
                    Discounts =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency = "currency",
                            Description = "description",
                        },
                    ],
                    Lines =
                    [
                        new()
                        {
                            Currency = "currency",
                            Description = "description",
                            SubTotal = 0,
                            UnitPrice = 0,
                            Quantity = 0,
                        },
                    ],
                    Tax = 0,
                },
                BillingPeriodRange = new()
                {
                    End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                FreeItems = [new() { AddonID = "addonId", Quantity = 0 }],
                HasScheduledUpdates = true,
                IsPlanDowngrade = true,
                RecurringInvoice = new()
                {
                    SubTotal = 0,
                    Total = 0,
                    BillingPeriodRange = new()
                    {
                        End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    Currency = "currency",
                    Discount = 0,
                    DiscountDetails = new()
                    {
                        Code = "code",
                        FixedAmount = 0,
                        Percentage = 0,
                    },
                    Discounts =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency = "currency",
                            Description = "description",
                        },
                    ],
                    Lines =
                    [
                        new()
                        {
                            Currency = "currency",
                            Description = "description",
                            SubTotal = 0,
                            UnitPrice = 0,
                            Quantity = 0,
                        },
                    ],
                    Tax = 0,
                },
            },
        };

        SubscriptionPreviewResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionPreviewResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionPreviewResponseData
        {
            ImmediateInvoice = new()
            {
                SubTotal = 0,
                Total = 0,
                BillingPeriodRange = new()
                {
                    End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Currency = "currency",
                Discount = 0,
                DiscountDetails = new()
                {
                    Code = "code",
                    FixedAmount = 0,
                    Percentage = 0,
                },
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        Currency = "currency",
                        Description = "description",
                    },
                ],
                Lines =
                [
                    new()
                    {
                        Currency = "currency",
                        Description = "description",
                        SubTotal = 0,
                        UnitPrice = 0,
                        Quantity = 0,
                    },
                ],
                Tax = 0,
            },
            BillingPeriodRange = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            FreeItems = [new() { AddonID = "addonId", Quantity = 0 }],
            HasScheduledUpdates = true,
            IsPlanDowngrade = true,
            RecurringInvoice = new()
            {
                SubTotal = 0,
                Total = 0,
                BillingPeriodRange = new()
                {
                    End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Currency = "currency",
                Discount = 0,
                DiscountDetails = new()
                {
                    Code = "code",
                    FixedAmount = 0,
                    Percentage = 0,
                },
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        Currency = "currency",
                        Description = "description",
                    },
                ],
                Lines =
                [
                    new()
                    {
                        Currency = "currency",
                        Description = "description",
                        SubTotal = 0,
                        UnitPrice = 0,
                        Quantity = 0,
                    },
                ],
                Tax = 0,
            },
        };

        ImmediateInvoice expectedImmediateInvoice = new()
        {
            SubTotal = 0,
            Total = 0,
            BillingPeriodRange = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Currency = "currency",
            Discount = 0,
            DiscountDetails = new()
            {
                Code = "code",
                FixedAmount = 0,
                Percentage = 0,
            },
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                },
            ],
            Lines =
            [
                new()
                {
                    Currency = "currency",
                    Description = "description",
                    SubTotal = 0,
                    UnitPrice = 0,
                    Quantity = 0,
                },
            ],
            Tax = 0,
        };
        SubscriptionPreviewResponseDataBillingPeriodRange expectedBillingPeriodRange = new()
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        List<FreeItem> expectedFreeItems = [new() { AddonID = "addonId", Quantity = 0 }];
        bool expectedHasScheduledUpdates = true;
        bool expectedIsPlanDowngrade = true;
        RecurringInvoice expectedRecurringInvoice = new()
        {
            SubTotal = 0,
            Total = 0,
            BillingPeriodRange = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Currency = "currency",
            Discount = 0,
            DiscountDetails = new()
            {
                Code = "code",
                FixedAmount = 0,
                Percentage = 0,
            },
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                },
            ],
            Lines =
            [
                new()
                {
                    Currency = "currency",
                    Description = "description",
                    SubTotal = 0,
                    UnitPrice = 0,
                    Quantity = 0,
                },
            ],
            Tax = 0,
        };

        Assert.Equal(expectedImmediateInvoice, model.ImmediateInvoice);
        Assert.Equal(expectedBillingPeriodRange, model.BillingPeriodRange);
        Assert.NotNull(model.FreeItems);
        Assert.Equal(expectedFreeItems.Count, model.FreeItems.Count);
        for (int i = 0; i < expectedFreeItems.Count; i++)
        {
            Assert.Equal(expectedFreeItems[i], model.FreeItems[i]);
        }
        Assert.Equal(expectedHasScheduledUpdates, model.HasScheduledUpdates);
        Assert.Equal(expectedIsPlanDowngrade, model.IsPlanDowngrade);
        Assert.Equal(expectedRecurringInvoice, model.RecurringInvoice);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionPreviewResponseData
        {
            ImmediateInvoice = new()
            {
                SubTotal = 0,
                Total = 0,
                BillingPeriodRange = new()
                {
                    End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Currency = "currency",
                Discount = 0,
                DiscountDetails = new()
                {
                    Code = "code",
                    FixedAmount = 0,
                    Percentage = 0,
                },
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        Currency = "currency",
                        Description = "description",
                    },
                ],
                Lines =
                [
                    new()
                    {
                        Currency = "currency",
                        Description = "description",
                        SubTotal = 0,
                        UnitPrice = 0,
                        Quantity = 0,
                    },
                ],
                Tax = 0,
            },
            BillingPeriodRange = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            FreeItems = [new() { AddonID = "addonId", Quantity = 0 }],
            HasScheduledUpdates = true,
            IsPlanDowngrade = true,
            RecurringInvoice = new()
            {
                SubTotal = 0,
                Total = 0,
                BillingPeriodRange = new()
                {
                    End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Currency = "currency",
                Discount = 0,
                DiscountDetails = new()
                {
                    Code = "code",
                    FixedAmount = 0,
                    Percentage = 0,
                },
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        Currency = "currency",
                        Description = "description",
                    },
                ],
                Lines =
                [
                    new()
                    {
                        Currency = "currency",
                        Description = "description",
                        SubTotal = 0,
                        UnitPrice = 0,
                        Quantity = 0,
                    },
                ],
                Tax = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionPreviewResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionPreviewResponseData
        {
            ImmediateInvoice = new()
            {
                SubTotal = 0,
                Total = 0,
                BillingPeriodRange = new()
                {
                    End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Currency = "currency",
                Discount = 0,
                DiscountDetails = new()
                {
                    Code = "code",
                    FixedAmount = 0,
                    Percentage = 0,
                },
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        Currency = "currency",
                        Description = "description",
                    },
                ],
                Lines =
                [
                    new()
                    {
                        Currency = "currency",
                        Description = "description",
                        SubTotal = 0,
                        UnitPrice = 0,
                        Quantity = 0,
                    },
                ],
                Tax = 0,
            },
            BillingPeriodRange = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            FreeItems = [new() { AddonID = "addonId", Quantity = 0 }],
            HasScheduledUpdates = true,
            IsPlanDowngrade = true,
            RecurringInvoice = new()
            {
                SubTotal = 0,
                Total = 0,
                BillingPeriodRange = new()
                {
                    End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Currency = "currency",
                Discount = 0,
                DiscountDetails = new()
                {
                    Code = "code",
                    FixedAmount = 0,
                    Percentage = 0,
                },
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        Currency = "currency",
                        Description = "description",
                    },
                ],
                Lines =
                [
                    new()
                    {
                        Currency = "currency",
                        Description = "description",
                        SubTotal = 0,
                        UnitPrice = 0,
                        Quantity = 0,
                    },
                ],
                Tax = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionPreviewResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ImmediateInvoice expectedImmediateInvoice = new()
        {
            SubTotal = 0,
            Total = 0,
            BillingPeriodRange = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Currency = "currency",
            Discount = 0,
            DiscountDetails = new()
            {
                Code = "code",
                FixedAmount = 0,
                Percentage = 0,
            },
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                },
            ],
            Lines =
            [
                new()
                {
                    Currency = "currency",
                    Description = "description",
                    SubTotal = 0,
                    UnitPrice = 0,
                    Quantity = 0,
                },
            ],
            Tax = 0,
        };
        SubscriptionPreviewResponseDataBillingPeriodRange expectedBillingPeriodRange = new()
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        List<FreeItem> expectedFreeItems = [new() { AddonID = "addonId", Quantity = 0 }];
        bool expectedHasScheduledUpdates = true;
        bool expectedIsPlanDowngrade = true;
        RecurringInvoice expectedRecurringInvoice = new()
        {
            SubTotal = 0,
            Total = 0,
            BillingPeriodRange = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Currency = "currency",
            Discount = 0,
            DiscountDetails = new()
            {
                Code = "code",
                FixedAmount = 0,
                Percentage = 0,
            },
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                },
            ],
            Lines =
            [
                new()
                {
                    Currency = "currency",
                    Description = "description",
                    SubTotal = 0,
                    UnitPrice = 0,
                    Quantity = 0,
                },
            ],
            Tax = 0,
        };

        Assert.Equal(expectedImmediateInvoice, deserialized.ImmediateInvoice);
        Assert.Equal(expectedBillingPeriodRange, deserialized.BillingPeriodRange);
        Assert.NotNull(deserialized.FreeItems);
        Assert.Equal(expectedFreeItems.Count, deserialized.FreeItems.Count);
        for (int i = 0; i < expectedFreeItems.Count; i++)
        {
            Assert.Equal(expectedFreeItems[i], deserialized.FreeItems[i]);
        }
        Assert.Equal(expectedHasScheduledUpdates, deserialized.HasScheduledUpdates);
        Assert.Equal(expectedIsPlanDowngrade, deserialized.IsPlanDowngrade);
        Assert.Equal(expectedRecurringInvoice, deserialized.RecurringInvoice);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionPreviewResponseData
        {
            ImmediateInvoice = new()
            {
                SubTotal = 0,
                Total = 0,
                BillingPeriodRange = new()
                {
                    End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Currency = "currency",
                Discount = 0,
                DiscountDetails = new()
                {
                    Code = "code",
                    FixedAmount = 0,
                    Percentage = 0,
                },
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        Currency = "currency",
                        Description = "description",
                    },
                ],
                Lines =
                [
                    new()
                    {
                        Currency = "currency",
                        Description = "description",
                        SubTotal = 0,
                        UnitPrice = 0,
                        Quantity = 0,
                    },
                ],
                Tax = 0,
            },
            BillingPeriodRange = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            FreeItems = [new() { AddonID = "addonId", Quantity = 0 }],
            HasScheduledUpdates = true,
            IsPlanDowngrade = true,
            RecurringInvoice = new()
            {
                SubTotal = 0,
                Total = 0,
                BillingPeriodRange = new()
                {
                    End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Currency = "currency",
                Discount = 0,
                DiscountDetails = new()
                {
                    Code = "code",
                    FixedAmount = 0,
                    Percentage = 0,
                },
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        Currency = "currency",
                        Description = "description",
                    },
                ],
                Lines =
                [
                    new()
                    {
                        Currency = "currency",
                        Description = "description",
                        SubTotal = 0,
                        UnitPrice = 0,
                        Quantity = 0,
                    },
                ],
                Tax = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionPreviewResponseData
        {
            ImmediateInvoice = new()
            {
                SubTotal = 0,
                Total = 0,
                BillingPeriodRange = new()
                {
                    End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Currency = "currency",
                Discount = 0,
                DiscountDetails = new()
                {
                    Code = "code",
                    FixedAmount = 0,
                    Percentage = 0,
                },
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        Currency = "currency",
                        Description = "description",
                    },
                ],
                Lines =
                [
                    new()
                    {
                        Currency = "currency",
                        Description = "description",
                        SubTotal = 0,
                        UnitPrice = 0,
                        Quantity = 0,
                    },
                ],
                Tax = 0,
            },
        };

        Assert.Null(model.BillingPeriodRange);
        Assert.False(model.RawData.ContainsKey("billingPeriodRange"));
        Assert.Null(model.FreeItems);
        Assert.False(model.RawData.ContainsKey("freeItems"));
        Assert.Null(model.HasScheduledUpdates);
        Assert.False(model.RawData.ContainsKey("hasScheduledUpdates"));
        Assert.Null(model.IsPlanDowngrade);
        Assert.False(model.RawData.ContainsKey("isPlanDowngrade"));
        Assert.Null(model.RecurringInvoice);
        Assert.False(model.RawData.ContainsKey("recurringInvoice"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionPreviewResponseData
        {
            ImmediateInvoice = new()
            {
                SubTotal = 0,
                Total = 0,
                BillingPeriodRange = new()
                {
                    End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Currency = "currency",
                Discount = 0,
                DiscountDetails = new()
                {
                    Code = "code",
                    FixedAmount = 0,
                    Percentage = 0,
                },
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        Currency = "currency",
                        Description = "description",
                    },
                ],
                Lines =
                [
                    new()
                    {
                        Currency = "currency",
                        Description = "description",
                        SubTotal = 0,
                        UnitPrice = 0,
                        Quantity = 0,
                    },
                ],
                Tax = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionPreviewResponseData
        {
            ImmediateInvoice = new()
            {
                SubTotal = 0,
                Total = 0,
                BillingPeriodRange = new()
                {
                    End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Currency = "currency",
                Discount = 0,
                DiscountDetails = new()
                {
                    Code = "code",
                    FixedAmount = 0,
                    Percentage = 0,
                },
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        Currency = "currency",
                        Description = "description",
                    },
                ],
                Lines =
                [
                    new()
                    {
                        Currency = "currency",
                        Description = "description",
                        SubTotal = 0,
                        UnitPrice = 0,
                        Quantity = 0,
                    },
                ],
                Tax = 0,
            },

            // Null should be interpreted as omitted for these properties
            BillingPeriodRange = null,
            FreeItems = null,
            HasScheduledUpdates = null,
            IsPlanDowngrade = null,
            RecurringInvoice = null,
        };

        Assert.Null(model.BillingPeriodRange);
        Assert.False(model.RawData.ContainsKey("billingPeriodRange"));
        Assert.Null(model.FreeItems);
        Assert.False(model.RawData.ContainsKey("freeItems"));
        Assert.Null(model.HasScheduledUpdates);
        Assert.False(model.RawData.ContainsKey("hasScheduledUpdates"));
        Assert.Null(model.IsPlanDowngrade);
        Assert.False(model.RawData.ContainsKey("isPlanDowngrade"));
        Assert.Null(model.RecurringInvoice);
        Assert.False(model.RawData.ContainsKey("recurringInvoice"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionPreviewResponseData
        {
            ImmediateInvoice = new()
            {
                SubTotal = 0,
                Total = 0,
                BillingPeriodRange = new()
                {
                    End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Currency = "currency",
                Discount = 0,
                DiscountDetails = new()
                {
                    Code = "code",
                    FixedAmount = 0,
                    Percentage = 0,
                },
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        Currency = "currency",
                        Description = "description",
                    },
                ],
                Lines =
                [
                    new()
                    {
                        Currency = "currency",
                        Description = "description",
                        SubTotal = 0,
                        UnitPrice = 0,
                        Quantity = 0,
                    },
                ],
                Tax = 0,
            },

            // Null should be interpreted as omitted for these properties
            BillingPeriodRange = null,
            FreeItems = null,
            HasScheduledUpdates = null,
            IsPlanDowngrade = null,
            RecurringInvoice = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionPreviewResponseData
        {
            ImmediateInvoice = new()
            {
                SubTotal = 0,
                Total = 0,
                BillingPeriodRange = new()
                {
                    End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Currency = "currency",
                Discount = 0,
                DiscountDetails = new()
                {
                    Code = "code",
                    FixedAmount = 0,
                    Percentage = 0,
                },
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        Currency = "currency",
                        Description = "description",
                    },
                ],
                Lines =
                [
                    new()
                    {
                        Currency = "currency",
                        Description = "description",
                        SubTotal = 0,
                        UnitPrice = 0,
                        Quantity = 0,
                    },
                ],
                Tax = 0,
            },
            BillingPeriodRange = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            FreeItems = [new() { AddonID = "addonId", Quantity = 0 }],
            HasScheduledUpdates = true,
            IsPlanDowngrade = true,
            RecurringInvoice = new()
            {
                SubTotal = 0,
                Total = 0,
                BillingPeriodRange = new()
                {
                    End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Currency = "currency",
                Discount = 0,
                DiscountDetails = new()
                {
                    Code = "code",
                    FixedAmount = 0,
                    Percentage = 0,
                },
                Discounts =
                [
                    new()
                    {
                        Amount = 0,
                        Currency = "currency",
                        Description = "description",
                    },
                ],
                Lines =
                [
                    new()
                    {
                        Currency = "currency",
                        Description = "description",
                        SubTotal = 0,
                        UnitPrice = 0,
                        Quantity = 0,
                    },
                ],
                Tax = 0,
            },
        };

        SubscriptionPreviewResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ImmediateInvoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ImmediateInvoice
        {
            SubTotal = 0,
            Total = 0,
            BillingPeriodRange = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Currency = "currency",
            Discount = 0,
            DiscountDetails = new()
            {
                Code = "code",
                FixedAmount = 0,
                Percentage = 0,
            },
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                },
            ],
            Lines =
            [
                new()
                {
                    Currency = "currency",
                    Description = "description",
                    SubTotal = 0,
                    UnitPrice = 0,
                    Quantity = 0,
                },
            ],
            Tax = 0,
        };

        double expectedSubTotal = 0;
        double expectedTotal = 0;
        BillingPeriodRange expectedBillingPeriodRange = new()
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedCurrency = "currency";
        double expectedDiscount = 0;
        DiscountDetails expectedDiscountDetails = new()
        {
            Code = "code",
            FixedAmount = 0,
            Percentage = 0,
        };
        List<ImmediateInvoiceDiscount> expectedDiscounts =
        [
            new()
            {
                Amount = 0,
                Currency = "currency",
                Description = "description",
            },
        ];
        List<Line> expectedLines =
        [
            new()
            {
                Currency = "currency",
                Description = "description",
                SubTotal = 0,
                UnitPrice = 0,
                Quantity = 0,
            },
        ];
        double expectedTax = 0;

        Assert.Equal(expectedSubTotal, model.SubTotal);
        Assert.Equal(expectedTotal, model.Total);
        Assert.Equal(expectedBillingPeriodRange, model.BillingPeriodRange);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedDiscountDetails, model.DiscountDetails);
        Assert.NotNull(model.Discounts);
        Assert.Equal(expectedDiscounts.Count, model.Discounts.Count);
        for (int i = 0; i < expectedDiscounts.Count; i++)
        {
            Assert.Equal(expectedDiscounts[i], model.Discounts[i]);
        }
        Assert.NotNull(model.Lines);
        Assert.Equal(expectedLines.Count, model.Lines.Count);
        for (int i = 0; i < expectedLines.Count; i++)
        {
            Assert.Equal(expectedLines[i], model.Lines[i]);
        }
        Assert.Equal(expectedTax, model.Tax);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ImmediateInvoice
        {
            SubTotal = 0,
            Total = 0,
            BillingPeriodRange = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Currency = "currency",
            Discount = 0,
            DiscountDetails = new()
            {
                Code = "code",
                FixedAmount = 0,
                Percentage = 0,
            },
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                },
            ],
            Lines =
            [
                new()
                {
                    Currency = "currency",
                    Description = "description",
                    SubTotal = 0,
                    UnitPrice = 0,
                    Quantity = 0,
                },
            ],
            Tax = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImmediateInvoice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ImmediateInvoice
        {
            SubTotal = 0,
            Total = 0,
            BillingPeriodRange = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Currency = "currency",
            Discount = 0,
            DiscountDetails = new()
            {
                Code = "code",
                FixedAmount = 0,
                Percentage = 0,
            },
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                },
            ],
            Lines =
            [
                new()
                {
                    Currency = "currency",
                    Description = "description",
                    SubTotal = 0,
                    UnitPrice = 0,
                    Quantity = 0,
                },
            ],
            Tax = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImmediateInvoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedSubTotal = 0;
        double expectedTotal = 0;
        BillingPeriodRange expectedBillingPeriodRange = new()
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedCurrency = "currency";
        double expectedDiscount = 0;
        DiscountDetails expectedDiscountDetails = new()
        {
            Code = "code",
            FixedAmount = 0,
            Percentage = 0,
        };
        List<ImmediateInvoiceDiscount> expectedDiscounts =
        [
            new()
            {
                Amount = 0,
                Currency = "currency",
                Description = "description",
            },
        ];
        List<Line> expectedLines =
        [
            new()
            {
                Currency = "currency",
                Description = "description",
                SubTotal = 0,
                UnitPrice = 0,
                Quantity = 0,
            },
        ];
        double expectedTax = 0;

        Assert.Equal(expectedSubTotal, deserialized.SubTotal);
        Assert.Equal(expectedTotal, deserialized.Total);
        Assert.Equal(expectedBillingPeriodRange, deserialized.BillingPeriodRange);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDiscount, deserialized.Discount);
        Assert.Equal(expectedDiscountDetails, deserialized.DiscountDetails);
        Assert.NotNull(deserialized.Discounts);
        Assert.Equal(expectedDiscounts.Count, deserialized.Discounts.Count);
        for (int i = 0; i < expectedDiscounts.Count; i++)
        {
            Assert.Equal(expectedDiscounts[i], deserialized.Discounts[i]);
        }
        Assert.NotNull(deserialized.Lines);
        Assert.Equal(expectedLines.Count, deserialized.Lines.Count);
        for (int i = 0; i < expectedLines.Count; i++)
        {
            Assert.Equal(expectedLines[i], deserialized.Lines[i]);
        }
        Assert.Equal(expectedTax, deserialized.Tax);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ImmediateInvoice
        {
            SubTotal = 0,
            Total = 0,
            BillingPeriodRange = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Currency = "currency",
            Discount = 0,
            DiscountDetails = new()
            {
                Code = "code",
                FixedAmount = 0,
                Percentage = 0,
            },
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                },
            ],
            Lines =
            [
                new()
                {
                    Currency = "currency",
                    Description = "description",
                    SubTotal = 0,
                    UnitPrice = 0,
                    Quantity = 0,
                },
            ],
            Tax = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ImmediateInvoice
        {
            SubTotal = 0,
            Total = 0,
            Currency = "currency",
        };

        Assert.Null(model.BillingPeriodRange);
        Assert.False(model.RawData.ContainsKey("billingPeriodRange"));
        Assert.Null(model.Discount);
        Assert.False(model.RawData.ContainsKey("discount"));
        Assert.Null(model.DiscountDetails);
        Assert.False(model.RawData.ContainsKey("discountDetails"));
        Assert.Null(model.Discounts);
        Assert.False(model.RawData.ContainsKey("discounts"));
        Assert.Null(model.Lines);
        Assert.False(model.RawData.ContainsKey("lines"));
        Assert.Null(model.Tax);
        Assert.False(model.RawData.ContainsKey("tax"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ImmediateInvoice
        {
            SubTotal = 0,
            Total = 0,
            Currency = "currency",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ImmediateInvoice
        {
            SubTotal = 0,
            Total = 0,
            Currency = "currency",

            // Null should be interpreted as omitted for these properties
            BillingPeriodRange = null,
            Discount = null,
            DiscountDetails = null,
            Discounts = null,
            Lines = null,
            Tax = null,
        };

        Assert.Null(model.BillingPeriodRange);
        Assert.False(model.RawData.ContainsKey("billingPeriodRange"));
        Assert.Null(model.Discount);
        Assert.False(model.RawData.ContainsKey("discount"));
        Assert.Null(model.DiscountDetails);
        Assert.False(model.RawData.ContainsKey("discountDetails"));
        Assert.Null(model.Discounts);
        Assert.False(model.RawData.ContainsKey("discounts"));
        Assert.Null(model.Lines);
        Assert.False(model.RawData.ContainsKey("lines"));
        Assert.Null(model.Tax);
        Assert.False(model.RawData.ContainsKey("tax"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ImmediateInvoice
        {
            SubTotal = 0,
            Total = 0,
            Currency = "currency",

            // Null should be interpreted as omitted for these properties
            BillingPeriodRange = null,
            Discount = null,
            DiscountDetails = null,
            Discounts = null,
            Lines = null,
            Tax = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ImmediateInvoice
        {
            SubTotal = 0,
            Total = 0,
            BillingPeriodRange = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Discount = 0,
            DiscountDetails = new()
            {
                Code = "code",
                FixedAmount = 0,
                Percentage = 0,
            },
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                },
            ],
            Lines =
            [
                new()
                {
                    Currency = "currency",
                    Description = "description",
                    SubTotal = 0,
                    UnitPrice = 0,
                    Quantity = 0,
                },
            ],
            Tax = 0,
        };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ImmediateInvoice
        {
            SubTotal = 0,
            Total = 0,
            BillingPeriodRange = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Discount = 0,
            DiscountDetails = new()
            {
                Code = "code",
                FixedAmount = 0,
                Percentage = 0,
            },
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                },
            ],
            Lines =
            [
                new()
                {
                    Currency = "currency",
                    Description = "description",
                    SubTotal = 0,
                    UnitPrice = 0,
                    Quantity = 0,
                },
            ],
            Tax = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ImmediateInvoice
        {
            SubTotal = 0,
            Total = 0,
            BillingPeriodRange = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Discount = 0,
            DiscountDetails = new()
            {
                Code = "code",
                FixedAmount = 0,
                Percentage = 0,
            },
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                },
            ],
            Lines =
            [
                new()
                {
                    Currency = "currency",
                    Description = "description",
                    SubTotal = 0,
                    UnitPrice = 0,
                    Quantity = 0,
                },
            ],
            Tax = 0,

            Currency = null,
        };

        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ImmediateInvoice
        {
            SubTotal = 0,
            Total = 0,
            BillingPeriodRange = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Discount = 0,
            DiscountDetails = new()
            {
                Code = "code",
                FixedAmount = 0,
                Percentage = 0,
            },
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                },
            ],
            Lines =
            [
                new()
                {
                    Currency = "currency",
                    Description = "description",
                    SubTotal = 0,
                    UnitPrice = 0,
                    Quantity = 0,
                },
            ],
            Tax = 0,

            Currency = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ImmediateInvoice
        {
            SubTotal = 0,
            Total = 0,
            BillingPeriodRange = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Currency = "currency",
            Discount = 0,
            DiscountDetails = new()
            {
                Code = "code",
                FixedAmount = 0,
                Percentage = 0,
            },
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                },
            ],
            Lines =
            [
                new()
                {
                    Currency = "currency",
                    Description = "description",
                    SubTotal = 0,
                    UnitPrice = 0,
                    Quantity = 0,
                },
            ],
            Tax = 0,
        };

        ImmediateInvoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BillingPeriodRangeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BillingPeriodRange
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedEnd, model.End);
        Assert.Equal(expectedStart, model.Start);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BillingPeriodRange
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BillingPeriodRange>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BillingPeriodRange
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BillingPeriodRange>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedEnd, deserialized.End);
        Assert.Equal(expectedStart, deserialized.Start);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BillingPeriodRange
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BillingPeriodRange
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        BillingPeriodRange copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DiscountDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DiscountDetails
        {
            Code = "code",
            FixedAmount = 0,
            Percentage = 0,
        };

        string expectedCode = "code";
        double expectedFixedAmount = 0;
        double expectedPercentage = 0;

        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedFixedAmount, model.FixedAmount);
        Assert.Equal(expectedPercentage, model.Percentage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DiscountDetails
        {
            Code = "code",
            FixedAmount = 0,
            Percentage = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DiscountDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DiscountDetails
        {
            Code = "code",
            FixedAmount = 0,
            Percentage = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DiscountDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCode = "code";
        double expectedFixedAmount = 0;
        double expectedPercentage = 0;

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedFixedAmount, deserialized.FixedAmount);
        Assert.Equal(expectedPercentage, deserialized.Percentage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DiscountDetails
        {
            Code = "code",
            FixedAmount = 0,
            Percentage = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DiscountDetails { };

        Assert.Null(model.Code);
        Assert.False(model.RawData.ContainsKey("code"));
        Assert.Null(model.FixedAmount);
        Assert.False(model.RawData.ContainsKey("fixedAmount"));
        Assert.Null(model.Percentage);
        Assert.False(model.RawData.ContainsKey("percentage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DiscountDetails { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DiscountDetails
        {
            // Null should be interpreted as omitted for these properties
            Code = null,
            FixedAmount = null,
            Percentage = null,
        };

        Assert.Null(model.Code);
        Assert.False(model.RawData.ContainsKey("code"));
        Assert.Null(model.FixedAmount);
        Assert.False(model.RawData.ContainsKey("fixedAmount"));
        Assert.Null(model.Percentage);
        Assert.False(model.RawData.ContainsKey("percentage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DiscountDetails
        {
            // Null should be interpreted as omitted for these properties
            Code = null,
            FixedAmount = null,
            Percentage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DiscountDetails
        {
            Code = "code",
            FixedAmount = 0,
            Percentage = 0,
        };

        DiscountDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ImmediateInvoiceDiscountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ImmediateInvoiceDiscount
        {
            Amount = 0,
            Currency = "currency",
            Description = "description",
        };

        double expectedAmount = 0;
        string expectedCurrency = "currency";
        string expectedDescription = "description";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ImmediateInvoiceDiscount
        {
            Amount = 0,
            Currency = "currency",
            Description = "description",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImmediateInvoiceDiscount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ImmediateInvoiceDiscount
        {
            Amount = 0,
            Currency = "currency",
            Description = "description",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ImmediateInvoiceDiscount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        string expectedCurrency = "currency";
        string expectedDescription = "description";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDescription, deserialized.Description);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ImmediateInvoiceDiscount
        {
            Amount = 0,
            Currency = "currency",
            Description = "description",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ImmediateInvoiceDiscount
        {
            Amount = 0,
            Currency = "currency",
            Description = "description",
        };

        ImmediateInvoiceDiscount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Line
        {
            Currency = "currency",
            Description = "description",
            SubTotal = 0,
            UnitPrice = 0,
            Quantity = 0,
        };

        string expectedCurrency = "currency";
        string expectedDescription = "description";
        double expectedSubTotal = 0;
        double expectedUnitPrice = 0;
        double expectedQuantity = 0;

        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedSubTotal, model.SubTotal);
        Assert.Equal(expectedUnitPrice, model.UnitPrice);
        Assert.Equal(expectedQuantity, model.Quantity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Line
        {
            Currency = "currency",
            Description = "description",
            SubTotal = 0,
            UnitPrice = 0,
            Quantity = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Line>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Line
        {
            Currency = "currency",
            Description = "description",
            SubTotal = 0,
            UnitPrice = 0,
            Quantity = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Line>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedCurrency = "currency";
        string expectedDescription = "description";
        double expectedSubTotal = 0;
        double expectedUnitPrice = 0;
        double expectedQuantity = 0;

        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedSubTotal, deserialized.SubTotal);
        Assert.Equal(expectedUnitPrice, deserialized.UnitPrice);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Line
        {
            Currency = "currency",
            Description = "description",
            SubTotal = 0,
            UnitPrice = 0,
            Quantity = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Line
        {
            Currency = "currency",
            Description = "description",
            SubTotal = 0,
            UnitPrice = 0,
        };

        Assert.Null(model.Quantity);
        Assert.False(model.RawData.ContainsKey("quantity"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Line
        {
            Currency = "currency",
            Description = "description",
            SubTotal = 0,
            UnitPrice = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Line
        {
            Currency = "currency",
            Description = "description",
            SubTotal = 0,
            UnitPrice = 0,

            // Null should be interpreted as omitted for these properties
            Quantity = null,
        };

        Assert.Null(model.Quantity);
        Assert.False(model.RawData.ContainsKey("quantity"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Line
        {
            Currency = "currency",
            Description = "description",
            SubTotal = 0,
            UnitPrice = 0,

            // Null should be interpreted as omitted for these properties
            Quantity = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Line
        {
            Currency = "currency",
            Description = "description",
            SubTotal = 0,
            UnitPrice = 0,
            Quantity = 0,
        };

        Line copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionPreviewResponseDataBillingPeriodRangeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionPreviewResponseDataBillingPeriodRange
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedEnd, model.End);
        Assert.Equal(expectedStart, model.Start);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionPreviewResponseDataBillingPeriodRange
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionPreviewResponseDataBillingPeriodRange>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionPreviewResponseDataBillingPeriodRange
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionPreviewResponseDataBillingPeriodRange>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedEnd, deserialized.End);
        Assert.Equal(expectedStart, deserialized.Start);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionPreviewResponseDataBillingPeriodRange
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionPreviewResponseDataBillingPeriodRange { };

        Assert.Null(model.End);
        Assert.False(model.RawData.ContainsKey("end"));
        Assert.Null(model.Start);
        Assert.False(model.RawData.ContainsKey("start"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionPreviewResponseDataBillingPeriodRange { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionPreviewResponseDataBillingPeriodRange
        {
            // Null should be interpreted as omitted for these properties
            End = null,
            Start = null,
        };

        Assert.Null(model.End);
        Assert.False(model.RawData.ContainsKey("end"));
        Assert.Null(model.Start);
        Assert.False(model.RawData.ContainsKey("start"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionPreviewResponseDataBillingPeriodRange
        {
            // Null should be interpreted as omitted for these properties
            End = null,
            Start = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionPreviewResponseDataBillingPeriodRange
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        SubscriptionPreviewResponseDataBillingPeriodRange copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class FreeItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new FreeItem { AddonID = "addonId", Quantity = 0 };

        string expectedAddonID = "addonId";
        double expectedQuantity = 0;

        Assert.Equal(expectedAddonID, model.AddonID);
        Assert.Equal(expectedQuantity, model.Quantity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new FreeItem { AddonID = "addonId", Quantity = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FreeItem>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new FreeItem { AddonID = "addonId", Quantity = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<FreeItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAddonID = "addonId";
        double expectedQuantity = 0;

        Assert.Equal(expectedAddonID, deserialized.AddonID);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new FreeItem { AddonID = "addonId", Quantity = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new FreeItem { AddonID = "addonId", Quantity = 0 };

        FreeItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RecurringInvoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RecurringInvoice
        {
            SubTotal = 0,
            Total = 0,
            BillingPeriodRange = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Currency = "currency",
            Discount = 0,
            DiscountDetails = new()
            {
                Code = "code",
                FixedAmount = 0,
                Percentage = 0,
            },
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                },
            ],
            Lines =
            [
                new()
                {
                    Currency = "currency",
                    Description = "description",
                    SubTotal = 0,
                    UnitPrice = 0,
                    Quantity = 0,
                },
            ],
            Tax = 0,
        };

        double expectedSubTotal = 0;
        double expectedTotal = 0;
        RecurringInvoiceBillingPeriodRange expectedBillingPeriodRange = new()
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedCurrency = "currency";
        double expectedDiscount = 0;
        RecurringInvoiceDiscountDetails expectedDiscountDetails = new()
        {
            Code = "code",
            FixedAmount = 0,
            Percentage = 0,
        };
        List<RecurringInvoiceDiscount> expectedDiscounts =
        [
            new()
            {
                Amount = 0,
                Currency = "currency",
                Description = "description",
            },
        ];
        List<RecurringInvoiceLine> expectedLines =
        [
            new()
            {
                Currency = "currency",
                Description = "description",
                SubTotal = 0,
                UnitPrice = 0,
                Quantity = 0,
            },
        ];
        double expectedTax = 0;

        Assert.Equal(expectedSubTotal, model.SubTotal);
        Assert.Equal(expectedTotal, model.Total);
        Assert.Equal(expectedBillingPeriodRange, model.BillingPeriodRange);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedDiscountDetails, model.DiscountDetails);
        Assert.NotNull(model.Discounts);
        Assert.Equal(expectedDiscounts.Count, model.Discounts.Count);
        for (int i = 0; i < expectedDiscounts.Count; i++)
        {
            Assert.Equal(expectedDiscounts[i], model.Discounts[i]);
        }
        Assert.NotNull(model.Lines);
        Assert.Equal(expectedLines.Count, model.Lines.Count);
        for (int i = 0; i < expectedLines.Count; i++)
        {
            Assert.Equal(expectedLines[i], model.Lines[i]);
        }
        Assert.Equal(expectedTax, model.Tax);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RecurringInvoice
        {
            SubTotal = 0,
            Total = 0,
            BillingPeriodRange = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Currency = "currency",
            Discount = 0,
            DiscountDetails = new()
            {
                Code = "code",
                FixedAmount = 0,
                Percentage = 0,
            },
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                },
            ],
            Lines =
            [
                new()
                {
                    Currency = "currency",
                    Description = "description",
                    SubTotal = 0,
                    UnitPrice = 0,
                    Quantity = 0,
                },
            ],
            Tax = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RecurringInvoice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RecurringInvoice
        {
            SubTotal = 0,
            Total = 0,
            BillingPeriodRange = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Currency = "currency",
            Discount = 0,
            DiscountDetails = new()
            {
                Code = "code",
                FixedAmount = 0,
                Percentage = 0,
            },
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                },
            ],
            Lines =
            [
                new()
                {
                    Currency = "currency",
                    Description = "description",
                    SubTotal = 0,
                    UnitPrice = 0,
                    Quantity = 0,
                },
            ],
            Tax = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RecurringInvoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedSubTotal = 0;
        double expectedTotal = 0;
        RecurringInvoiceBillingPeriodRange expectedBillingPeriodRange = new()
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedCurrency = "currency";
        double expectedDiscount = 0;
        RecurringInvoiceDiscountDetails expectedDiscountDetails = new()
        {
            Code = "code",
            FixedAmount = 0,
            Percentage = 0,
        };
        List<RecurringInvoiceDiscount> expectedDiscounts =
        [
            new()
            {
                Amount = 0,
                Currency = "currency",
                Description = "description",
            },
        ];
        List<RecurringInvoiceLine> expectedLines =
        [
            new()
            {
                Currency = "currency",
                Description = "description",
                SubTotal = 0,
                UnitPrice = 0,
                Quantity = 0,
            },
        ];
        double expectedTax = 0;

        Assert.Equal(expectedSubTotal, deserialized.SubTotal);
        Assert.Equal(expectedTotal, deserialized.Total);
        Assert.Equal(expectedBillingPeriodRange, deserialized.BillingPeriodRange);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDiscount, deserialized.Discount);
        Assert.Equal(expectedDiscountDetails, deserialized.DiscountDetails);
        Assert.NotNull(deserialized.Discounts);
        Assert.Equal(expectedDiscounts.Count, deserialized.Discounts.Count);
        for (int i = 0; i < expectedDiscounts.Count; i++)
        {
            Assert.Equal(expectedDiscounts[i], deserialized.Discounts[i]);
        }
        Assert.NotNull(deserialized.Lines);
        Assert.Equal(expectedLines.Count, deserialized.Lines.Count);
        for (int i = 0; i < expectedLines.Count; i++)
        {
            Assert.Equal(expectedLines[i], deserialized.Lines[i]);
        }
        Assert.Equal(expectedTax, deserialized.Tax);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RecurringInvoice
        {
            SubTotal = 0,
            Total = 0,
            BillingPeriodRange = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Currency = "currency",
            Discount = 0,
            DiscountDetails = new()
            {
                Code = "code",
                FixedAmount = 0,
                Percentage = 0,
            },
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                },
            ],
            Lines =
            [
                new()
                {
                    Currency = "currency",
                    Description = "description",
                    SubTotal = 0,
                    UnitPrice = 0,
                    Quantity = 0,
                },
            ],
            Tax = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RecurringInvoice
        {
            SubTotal = 0,
            Total = 0,
            Currency = "currency",
        };

        Assert.Null(model.BillingPeriodRange);
        Assert.False(model.RawData.ContainsKey("billingPeriodRange"));
        Assert.Null(model.Discount);
        Assert.False(model.RawData.ContainsKey("discount"));
        Assert.Null(model.DiscountDetails);
        Assert.False(model.RawData.ContainsKey("discountDetails"));
        Assert.Null(model.Discounts);
        Assert.False(model.RawData.ContainsKey("discounts"));
        Assert.Null(model.Lines);
        Assert.False(model.RawData.ContainsKey("lines"));
        Assert.Null(model.Tax);
        Assert.False(model.RawData.ContainsKey("tax"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RecurringInvoice
        {
            SubTotal = 0,
            Total = 0,
            Currency = "currency",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RecurringInvoice
        {
            SubTotal = 0,
            Total = 0,
            Currency = "currency",

            // Null should be interpreted as omitted for these properties
            BillingPeriodRange = null,
            Discount = null,
            DiscountDetails = null,
            Discounts = null,
            Lines = null,
            Tax = null,
        };

        Assert.Null(model.BillingPeriodRange);
        Assert.False(model.RawData.ContainsKey("billingPeriodRange"));
        Assert.Null(model.Discount);
        Assert.False(model.RawData.ContainsKey("discount"));
        Assert.Null(model.DiscountDetails);
        Assert.False(model.RawData.ContainsKey("discountDetails"));
        Assert.Null(model.Discounts);
        Assert.False(model.RawData.ContainsKey("discounts"));
        Assert.Null(model.Lines);
        Assert.False(model.RawData.ContainsKey("lines"));
        Assert.Null(model.Tax);
        Assert.False(model.RawData.ContainsKey("tax"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RecurringInvoice
        {
            SubTotal = 0,
            Total = 0,
            Currency = "currency",

            // Null should be interpreted as omitted for these properties
            BillingPeriodRange = null,
            Discount = null,
            DiscountDetails = null,
            Discounts = null,
            Lines = null,
            Tax = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RecurringInvoice
        {
            SubTotal = 0,
            Total = 0,
            BillingPeriodRange = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Discount = 0,
            DiscountDetails = new()
            {
                Code = "code",
                FixedAmount = 0,
                Percentage = 0,
            },
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                },
            ],
            Lines =
            [
                new()
                {
                    Currency = "currency",
                    Description = "description",
                    SubTotal = 0,
                    UnitPrice = 0,
                    Quantity = 0,
                },
            ],
            Tax = 0,
        };

        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new RecurringInvoice
        {
            SubTotal = 0,
            Total = 0,
            BillingPeriodRange = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Discount = 0,
            DiscountDetails = new()
            {
                Code = "code",
                FixedAmount = 0,
                Percentage = 0,
            },
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                },
            ],
            Lines =
            [
                new()
                {
                    Currency = "currency",
                    Description = "description",
                    SubTotal = 0,
                    UnitPrice = 0,
                    Quantity = 0,
                },
            ],
            Tax = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new RecurringInvoice
        {
            SubTotal = 0,
            Total = 0,
            BillingPeriodRange = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Discount = 0,
            DiscountDetails = new()
            {
                Code = "code",
                FixedAmount = 0,
                Percentage = 0,
            },
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                },
            ],
            Lines =
            [
                new()
                {
                    Currency = "currency",
                    Description = "description",
                    SubTotal = 0,
                    UnitPrice = 0,
                    Quantity = 0,
                },
            ],
            Tax = 0,

            Currency = null,
        };

        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RecurringInvoice
        {
            SubTotal = 0,
            Total = 0,
            BillingPeriodRange = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Discount = 0,
            DiscountDetails = new()
            {
                Code = "code",
                FixedAmount = 0,
                Percentage = 0,
            },
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                },
            ],
            Lines =
            [
                new()
                {
                    Currency = "currency",
                    Description = "description",
                    SubTotal = 0,
                    UnitPrice = 0,
                    Quantity = 0,
                },
            ],
            Tax = 0,

            Currency = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RecurringInvoice
        {
            SubTotal = 0,
            Total = 0,
            BillingPeriodRange = new()
            {
                End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Currency = "currency",
            Discount = 0,
            DiscountDetails = new()
            {
                Code = "code",
                FixedAmount = 0,
                Percentage = 0,
            },
            Discounts =
            [
                new()
                {
                    Amount = 0,
                    Currency = "currency",
                    Description = "description",
                },
            ],
            Lines =
            [
                new()
                {
                    Currency = "currency",
                    Description = "description",
                    SubTotal = 0,
                    UnitPrice = 0,
                    Quantity = 0,
                },
            ],
            Tax = 0,
        };

        RecurringInvoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RecurringInvoiceBillingPeriodRangeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RecurringInvoiceBillingPeriodRange
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedEnd, model.End);
        Assert.Equal(expectedStart, model.Start);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RecurringInvoiceBillingPeriodRange
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RecurringInvoiceBillingPeriodRange>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RecurringInvoiceBillingPeriodRange
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RecurringInvoiceBillingPeriodRange>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedEnd, deserialized.End);
        Assert.Equal(expectedStart, deserialized.Start);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RecurringInvoiceBillingPeriodRange
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RecurringInvoiceBillingPeriodRange
        {
            End = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Start = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        RecurringInvoiceBillingPeriodRange copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RecurringInvoiceDiscountDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RecurringInvoiceDiscountDetails
        {
            Code = "code",
            FixedAmount = 0,
            Percentage = 0,
        };

        string expectedCode = "code";
        double expectedFixedAmount = 0;
        double expectedPercentage = 0;

        Assert.Equal(expectedCode, model.Code);
        Assert.Equal(expectedFixedAmount, model.FixedAmount);
        Assert.Equal(expectedPercentage, model.Percentage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RecurringInvoiceDiscountDetails
        {
            Code = "code",
            FixedAmount = 0,
            Percentage = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RecurringInvoiceDiscountDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RecurringInvoiceDiscountDetails
        {
            Code = "code",
            FixedAmount = 0,
            Percentage = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RecurringInvoiceDiscountDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCode = "code";
        double expectedFixedAmount = 0;
        double expectedPercentage = 0;

        Assert.Equal(expectedCode, deserialized.Code);
        Assert.Equal(expectedFixedAmount, deserialized.FixedAmount);
        Assert.Equal(expectedPercentage, deserialized.Percentage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RecurringInvoiceDiscountDetails
        {
            Code = "code",
            FixedAmount = 0,
            Percentage = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RecurringInvoiceDiscountDetails { };

        Assert.Null(model.Code);
        Assert.False(model.RawData.ContainsKey("code"));
        Assert.Null(model.FixedAmount);
        Assert.False(model.RawData.ContainsKey("fixedAmount"));
        Assert.Null(model.Percentage);
        Assert.False(model.RawData.ContainsKey("percentage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RecurringInvoiceDiscountDetails { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RecurringInvoiceDiscountDetails
        {
            // Null should be interpreted as omitted for these properties
            Code = null,
            FixedAmount = null,
            Percentage = null,
        };

        Assert.Null(model.Code);
        Assert.False(model.RawData.ContainsKey("code"));
        Assert.Null(model.FixedAmount);
        Assert.False(model.RawData.ContainsKey("fixedAmount"));
        Assert.Null(model.Percentage);
        Assert.False(model.RawData.ContainsKey("percentage"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RecurringInvoiceDiscountDetails
        {
            // Null should be interpreted as omitted for these properties
            Code = null,
            FixedAmount = null,
            Percentage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RecurringInvoiceDiscountDetails
        {
            Code = "code",
            FixedAmount = 0,
            Percentage = 0,
        };

        RecurringInvoiceDiscountDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RecurringInvoiceDiscountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RecurringInvoiceDiscount
        {
            Amount = 0,
            Currency = "currency",
            Description = "description",
        };

        double expectedAmount = 0;
        string expectedCurrency = "currency";
        string expectedDescription = "description";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RecurringInvoiceDiscount
        {
            Amount = 0,
            Currency = "currency",
            Description = "description",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RecurringInvoiceDiscount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RecurringInvoiceDiscount
        {
            Amount = 0,
            Currency = "currency",
            Description = "description",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RecurringInvoiceDiscount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        string expectedCurrency = "currency";
        string expectedDescription = "description";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDescription, deserialized.Description);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RecurringInvoiceDiscount
        {
            Amount = 0,
            Currency = "currency",
            Description = "description",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RecurringInvoiceDiscount
        {
            Amount = 0,
            Currency = "currency",
            Description = "description",
        };

        RecurringInvoiceDiscount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class RecurringInvoiceLineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new RecurringInvoiceLine
        {
            Currency = "currency",
            Description = "description",
            SubTotal = 0,
            UnitPrice = 0,
            Quantity = 0,
        };

        string expectedCurrency = "currency";
        string expectedDescription = "description";
        double expectedSubTotal = 0;
        double expectedUnitPrice = 0;
        double expectedQuantity = 0;

        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedSubTotal, model.SubTotal);
        Assert.Equal(expectedUnitPrice, model.UnitPrice);
        Assert.Equal(expectedQuantity, model.Quantity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new RecurringInvoiceLine
        {
            Currency = "currency",
            Description = "description",
            SubTotal = 0,
            UnitPrice = 0,
            Quantity = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RecurringInvoiceLine>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new RecurringInvoiceLine
        {
            Currency = "currency",
            Description = "description",
            SubTotal = 0,
            UnitPrice = 0,
            Quantity = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<RecurringInvoiceLine>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCurrency = "currency";
        string expectedDescription = "description";
        double expectedSubTotal = 0;
        double expectedUnitPrice = 0;
        double expectedQuantity = 0;

        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedSubTotal, deserialized.SubTotal);
        Assert.Equal(expectedUnitPrice, deserialized.UnitPrice);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new RecurringInvoiceLine
        {
            Currency = "currency",
            Description = "description",
            SubTotal = 0,
            UnitPrice = 0,
            Quantity = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new RecurringInvoiceLine
        {
            Currency = "currency",
            Description = "description",
            SubTotal = 0,
            UnitPrice = 0,
        };

        Assert.Null(model.Quantity);
        Assert.False(model.RawData.ContainsKey("quantity"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new RecurringInvoiceLine
        {
            Currency = "currency",
            Description = "description",
            SubTotal = 0,
            UnitPrice = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new RecurringInvoiceLine
        {
            Currency = "currency",
            Description = "description",
            SubTotal = 0,
            UnitPrice = 0,

            // Null should be interpreted as omitted for these properties
            Quantity = null,
        };

        Assert.Null(model.Quantity);
        Assert.False(model.RawData.ContainsKey("quantity"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new RecurringInvoiceLine
        {
            Currency = "currency",
            Description = "description",
            SubTotal = 0,
            UnitPrice = 0,

            // Null should be interpreted as omitted for these properties
            Quantity = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new RecurringInvoiceLine
        {
            Currency = "currency",
            Description = "description",
            SubTotal = 0,
            UnitPrice = 0,
            Quantity = 0,
        };

        RecurringInvoiceLine copied = new(model);

        Assert.Equal(model, copied);
    }
}
