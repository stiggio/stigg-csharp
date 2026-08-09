# Changelog

## 0.9.0 (2026-08-05)

Full Changelog: [v0.8.0...v0.9.0](https://github.com/stiggio/stigg-csharp/compare/v0.8.0...v0.9.0)

### Features

* **api:** add consume/consumeAsync methods to credits consumption ([e757fac](https://github.com/stiggio/stigg-csharp/commit/e757fac28699b0ad3ccb13845c1b4cd9e3e61ced))
* **api:** add consumed field to Credit model ([e2c083b](https://github.com/stiggio/stigg-csharp/commit/e2c083b73a4c6dcc050a14e20b9479759f78f290))
* **api:** add consumption/estimate endpoints, move governance to v1-beta, update types ([8172de2](https://github.com/stiggio/stigg-csharp/commit/8172de20d60495d95ad0ab82fb4813b23aa8a0d7))
* **api:** add CreditEntitlement field to overage pricing model in addons/plans ([e63627d](https://github.com/stiggio/stigg-csharp/commit/e63627d096a4aa8cda4607641e1404fbbbf7003d))
* **api:** add DisplayName to entities, Description to entity types ([9b2cea4](https://github.com/stiggio/stigg-csharp/commit/9b2cea46b5825b7da1da60dde3253642b1b0a6b2))
* **api:** add estimate endpoints to customers events and usage ([2d97ccc](https://github.com/stiggio/stigg-csharp/commit/2d97ccc873f6e8df3c4d6e3817d328a5784ff08b))
* **api:** add EventCount to credit usage Series/Point models ([4ba3c89](https://github.com/stiggio/stigg-csharp/commit/4ba3c89a126bcb5c605552e37a7a79663b37c036))
* **api:** add EventType parameter to credits list ledger method ([2ebb692](https://github.com/stiggio/stigg-csharp/commit/2ebb692994aa41849d047e7a4b2f0e63d70b8efa))
* **api:** add featureId, rename capabilityId to currencyId in customer assignments list ([898d5a6](https://github.com/stiggio/stigg-csharp/commit/898d5a64a24c0b6ac9d4650924b5b59f88810b0f))
* **api:** add IdempotencyKey parameter to usage report ([42d68a8](https://github.com/stiggio/stigg-csharp/commit/42d68a8ff080d5d96745fbfc54d282135d4697f9))
* **api:** add syncStates field to credit grants responses ([e7c9023](https://github.com/stiggio/stigg-csharp/commit/e7c9023ec31888e8b92a6350286ba40cb2f6e770))
* **contracts:** create contracts backed by shared Received enterprise contract ([650d331](https://github.com/stiggio/stigg-csharp/commit/650d3319ebd92695802741ffde6af6c4cf9ef2fa))
* **STIGG-8091:** introduce Airwallex payment provider integration ([68b5377](https://github.com/stiggio/stigg-csharp/commit/68b5377d8950db813bcbf0918c3c4c5a2d2d3631))
* **stlc:** configurable CI runner and private-production-repo support in workflow templates ([a430e6b](https://github.com/stiggio/stigg-csharp/commit/a430e6b5032fe015e4793e7f177eccc33bf3ba22))
* **types:** add StripeInvoicing to customer vendor identifier enums ([36c4160](https://github.com/stiggio/stigg-csharp/commit/36c41600572bc9fd6f708b5a1d6a0bfe92a5f859))


### Bug Fixes

* **client:** tolerate JSON null in required untyped fields and prefer more specific union variants ([98aae53](https://github.com/stiggio/stigg-csharp/commit/98aae538889e7c80ee71b76aa9770018b635f14c))
* **types:** rename entity type fields to EntityTypeID in entity/governance models ([439d0cd](https://github.com/stiggio/stigg-csharp/commit/439d0cd472cbebac8094386b66ceb326c680bda8))


### Chores

* **internal:** regenerate SDK with no functional changes ([23871a2](https://github.com/stiggio/stigg-csharp/commit/23871a2e2680fe52a5e0b8ea9087d40e927195cd))
* **internal:** regenerate SDK with no functional changes ([3785c98](https://github.com/stiggio/stigg-csharp/commit/3785c98b52d276fc4c913a27adfc6ecbbc1836a5))
* **tests:** update MaxQuantity test fixtures in addons ([bc2fc97](https://github.com/stiggio/stigg-csharp/commit/bc2fc97ac4f46e77f932397c3dac70c59ca33759))


### Documentation

* **api:** update customers provision method description ([551433a](https://github.com/stiggio/stigg-csharp/commit/551433a0cc22eb8e37c53c1f49bbc1abde82826b))
* **api:** update destination delete method documentation in data export ([4d73d47](https://github.com/stiggio/stigg-csharp/commit/4d73d47e0e805665a1ed81f08eebb60cc9a3157d))

## 0.8.0 (2026-06-28)

Full Changelog: [v0.7.1...v0.8.0](https://github.com/stiggio/stigg-csharp/compare/v0.7.1...v0.8.0)

### Features

* **api:** add cancellation_date to subscription provision and update params ([38a027d](https://github.com/stiggio/stigg-csharp/commit/38a027d17503ebe25d33be0d467e47b5b52b0f58))
* **api:** add connection_status and last_sync_status fields to data export destinations ([abc2359](https://github.com/stiggio/stigg-csharp/commit/abc235922c4ca4eb62287e73b8ba0c2a2ec756ee))
* **api:** add credit field to usage report response ([99dcd46](https://github.com/stiggio/stigg-csharp/commit/99dcd46429b7ded5a645cb69736302d64c591466))
* **api:** add data export scoped token/sync, destinations create/delete ([21eece7](https://github.com/stiggio/stigg-csharp/commit/21eece7e6f0f67bf132022851e14df1d07a516a5))
* **api:** add HasSoftLimit field to addon and plan entitlements ([be3ef61](https://github.com/stiggio/stigg-csharp/commit/be3ef612eafbff0c32a9639a90e4c202495c7d51))
* **api:** add ListModels endpoint, EnabledModels field to data export ([7f86406](https://github.com/stiggio/stigg-csharp/commit/7f864065df26ab73675fda4317223d99d04e8faa))
* **api:** add RetrieveGovernance endpoint to v1-beta customers ([c7384a3](https://github.com/stiggio/stigg-csharp/commit/c7384a373551b774b8efd2e4d3fac6664d60cdbb))
* **api:** add SalesforceID parameter to subscription update ([32a7a81](https://github.com/stiggio/stigg-csharp/commit/32a7a81f395af3d662896932c7529c3991123b2e))
* **api:** add scope_entity_ids field to entitlement check response ([52451f7](https://github.com/stiggio/stigg-csharp/commit/52451f7d6514503493ba9391beb64885d6278521))
* **api:** add update method to data export destinations ([63086c5](https://github.com/stiggio/stigg-csharp/commit/63086c5fd877bbb60ebb8bab94efd2ea4960106a))
* **api:** add UsagePeriodEnd field to usage Credit model ([96b1376](https://github.com/stiggio/stigg-csharp/commit/96b13762587ef992c53e24b0709caceb3264e09d))
* **api:** add XAccountID/XEnvironmentID header parameters across all endpoints ([63e23fc](https://github.com/stiggio/stigg-csharp/commit/63e23fcd5afab8a08759d89aaf0a0b9c824e2cd6))
* **api:** manual updates ([990fcfb](https://github.com/stiggio/stigg-csharp/commit/990fcfb9c48e12cab71428e96174310807d893d4))
* **api:** manual updates ([bd1a67d](https://github.com/stiggio/stigg-csharp/commit/bd1a67d2c142a66d5b5cb05ebd4ccd874c14de4b))
* **api:** remove capabilityId, add currency/feature/parent/scope fields to assignments ([052ad4d](https://github.com/stiggio/stigg-csharp/commit/052ad4d2d7fa295f9a653aa7e4fa95927becf91b))
* **stainless:** update production server to edge.api.stigg.io ([cd0e0dd](https://github.com/stiggio/stigg-csharp/commit/cd0e0dd3c897794f499e6d8e3adfae8b5225146f))
* **STIGG-7296:** offset/limit pagination for credit usage ([a42f73c](https://github.com/stiggio/stigg-csharp/commit/a42f73cadf465149d0ed22c264d4fc8be4e3d054))


### Bug Fixes

* **STIGG-7921:** block syncing plans with package pricing model to Zuora ([cab262b](https://github.com/stiggio/stigg-csharp/commit/cab262b6514388b464dc8e64aa44b38aa4bd0cde))
* **types:** change Cadence from enum to string in assignments models ([0861c9f](https://github.com/stiggio/stigg-csharp/commit/0861c9fd50e7a72f5c5e61bf97c8cbe8bc7a29f8))
* **types:** make UsageLimit nullable in assignments ([ffdf78b](https://github.com/stiggio/stigg-csharp/commit/ffdf78b97bdde5788c5d4c82bcaafff73f87895b))

## 0.7.1 (2026-06-01)

Full Changelog: [v0.7.0...v0.7.1](https://github.com/stiggio/stigg-csharp/compare/v0.7.0...v0.7.1)

### Chores

* remove custom code ([878edc5](https://github.com/stiggio/stigg-csharp/commit/878edc5cdbb5ca8551c6b65f6b1ef4e4c4378490))

## 0.7.0 (2026-02-18)

Full Changelog: [v0.6.0...v0.7.0](https://github.com/stiggio/stigg-csharp/compare/v0.6.0...v0.7.0)

### Features

* **api:** add additional endpoints ([0c2de16](https://github.com/stiggio/stigg-csharp/commit/0c2de167a8ca5a30e4e7c8e16cedbdb57e237710))
* **api:** Add missing endpoints ([5e81b21](https://github.com/stiggio/stigg-csharp/commit/5e81b21c25cf76f8879ef5b664894dcb7c393be7))
* **api:** api update ([596218b](https://github.com/stiggio/stigg-csharp/commit/596218baaa277381cd2fa53aaa3ead3591b24715))
* **api:** api update ([929d367](https://github.com/stiggio/stigg-csharp/commit/929d367ebca44db9ca956c09b316698a73a9e2a4))
* **api:** api update ([ef15b40](https://github.com/stiggio/stigg-csharp/commit/ef15b409f4e5a0e473e09163c2ec43b15bcc7ab5))
* **api:** api update ([30ff37c](https://github.com/stiggio/stigg-csharp/commit/30ff37cdc0fa2aa2a64229078cb8932466decb24))
* **api:** api update ([4419e7a](https://github.com/stiggio/stigg-csharp/commit/4419e7a880d74da5c36756a3c7502f9aa9e59cbf))
* **api:** api update ([736b4ef](https://github.com/stiggio/stigg-csharp/commit/736b4efee16e4dfed74a8376c554ce3034952c28))
* **api:** api update ([6b0b08d](https://github.com/stiggio/stigg-csharp/commit/6b0b08d76121394e69855d74f9190c36e93eee94))
* **api:** api update ([e14907c](https://github.com/stiggio/stigg-csharp/commit/e14907cc89449e20ba93fecdeb5014888f094649))
* **api:** api update ([57440a9](https://github.com/stiggio/stigg-csharp/commit/57440a91996da5669c6b04ace7c12926ad3eabef))
* **api:** api update ([46760be](https://github.com/stiggio/stigg-csharp/commit/46760be93ec363208c9b7f3dc03618dde62111af))
* **api:** manual updates ([2ad0913](https://github.com/stiggio/stigg-csharp/commit/2ad0913622884ac37da899e23d5091de69d6a1dd))
* **api:** manual updates ([4a0b0b7](https://github.com/stiggio/stigg-csharp/commit/4a0b0b7b3eac6c959aecba1f6c9a5bddd6f5348d))
* **api:** manual updates ([4a0b0b7](https://github.com/stiggio/stigg-csharp/commit/4a0b0b7b3eac6c959aecba1f6c9a5bddd6f5348d))
* **api:** manual updates ([4c1b277](https://github.com/stiggio/stigg-csharp/commit/4c1b277a4cc1bf87c8524bbc15df19d1ceb29c67))
* **api:** manual updates ([8b05cef](https://github.com/stiggio/stigg-csharp/commit/8b05cefebe430bdc6848e63af1b9d6bb61bbaf75))
* **api:** manual updates ([af38bc7](https://github.com/stiggio/stigg-csharp/commit/af38bc7870ba5d9a933b569c8800ea3851709098))
* **api:** trigger release ([c8052a4](https://github.com/stiggio/stigg-csharp/commit/c8052a46f01d1c380496becc5efeaf4f4eed7fd0))
* **api:** trigger release ([c8052a4](https://github.com/stiggio/stigg-csharp/commit/c8052a46f01d1c380496becc5efeaf4f4eed7fd0))
* **api:** updated the production environment ([bba2b91](https://github.com/stiggio/stigg-csharp/commit/bba2b91415b80e0c7841f8d79c858158b829a429))
* **client:** add equality and tostring for multipart data ([f3743df](https://github.com/stiggio/stigg-csharp/commit/f3743df232daa55e09e9abea302912711171a6a1))


### Bug Fixes

* **client:** improve behaviour for comma-delimited binary content in multipart requests ([b39e11a](https://github.com/stiggio/stigg-csharp/commit/b39e11ab92c4d123e38bb35d05aa9420b2702fe2))


### Chores

* remove custom code ([851685d](https://github.com/stiggio/stigg-csharp/commit/851685d1a2f5242711b77c4212585ec79817c1e0))

## 0.6.0 (2026-02-08)

Full Changelog: [v0.5.0...v0.6.0](https://github.com/stiggio/stigg-csharp/compare/v0.5.0...v0.6.0)

### Features

* **api:** api update ([3affd0d](https://github.com/stiggio/stigg-csharp/commit/3affd0d92f7a04e5646f3b6d823af875f4ffc688))
* **api:** api update ([f692738](https://github.com/stiggio/stigg-csharp/commit/f692738b43d3df8fce685e6beece5bd3307ae48f))
* **api:** api update ([c0f0c9c](https://github.com/stiggio/stigg-csharp/commit/c0f0c9c4c48de24d1b865beb50aeead53d6f42f8))
* **api:** manual updates ([2460363](https://github.com/stiggio/stigg-csharp/commit/246036366bf229a022dc96aef873dc053522b0b3))
* **api:** manual updates ([1d26608](https://github.com/stiggio/stigg-csharp/commit/1d26608aad9f924bce10f1414d3542ed3fda72ab))


### Bug Fixes

* **client:** improve union equality method ([96ddcc2](https://github.com/stiggio/stigg-csharp/commit/96ddcc20ade60c858cea6f2bb113ad79b194c5e9))


### Chores

* **internal:** ignore stainless-internal artifacts ([cf88d00](https://github.com/stiggio/stigg-csharp/commit/cf88d00eadb439a972843537c266eb7126aa2bc6))

## 0.5.0 (2026-01-29)

Full Changelog: [v0.4.0...v0.5.0](https://github.com/stiggio/stigg-csharp/compare/v0.4.0...v0.5.0)

### Features

* **api:** update stainless config ([14fedc3](https://github.com/stiggio/stigg-csharp/commit/14fedc33b86c72e21c0822bc60585d8273cf30e8))

## 0.4.0 (2026-01-28)

Full Changelog: [v0.3.1...v0.4.0](https://github.com/stiggio/stigg-csharp/compare/v0.3.1...v0.4.0)

### Features

* **api:** api update ([6f5ec3e](https://github.com/stiggio/stigg-csharp/commit/6f5ec3e8ffe7915affcd3d8a2592d8c3ddb66694))
* **api:** api update ([60eef92](https://github.com/stiggio/stigg-csharp/commit/60eef9248a3c70c1bc07d300deba7036248af344))


### Bug Fixes

* **client:** handle unions containing unknown types properly ([f49471b](https://github.com/stiggio/stigg-csharp/commit/f49471b9d3a1609109b5baf4e4a9cd0024f328e8))


### Chores

* **internal:** improve HttpResponse qualification ([2f99574](https://github.com/stiggio/stigg-csharp/commit/2f9957426c6db9c6027a7dad8c21598b93c51cdb))

## 0.3.1 (2026-01-27)

Full Changelog: [v0.3.0...v0.3.1](https://github.com/stiggio/stigg-csharp/compare/v0.3.0...v0.3.1)

### Chores

* remove custom code ([b5de96f](https://github.com/stiggio/stigg-csharp/commit/b5de96fd33edc895eb0945b1a42bde5c8a79131b))

## 0.3.0 (2026-01-27)

Full Changelog: [v0.2.0...v0.3.0](https://github.com/stiggio/stigg-csharp/compare/v0.2.0...v0.3.0)

### Features

* **api:** api update ([40dc9b7](https://github.com/stiggio/stigg-csharp/commit/40dc9b72e62791808562c7ad203124bbbce67c6c))
* **api:** api update ([4b0be39](https://github.com/stiggio/stigg-csharp/commit/4b0be39c8f34f896de3f29b34751db9050209a37))
* **api:** improved cursor pagination ([66b0de9](https://github.com/stiggio/stigg-csharp/commit/66b0de9926a3976f701972a46d59adf5a0684ab9))

## 0.2.0 (2026-01-27)

Full Changelog: [v0.1.0...v0.2.0](https://github.com/stiggio/stigg-csharp/compare/v0.1.0...v0.2.0)

### Features

* **api:** api update ([51eb94c](https://github.com/stiggio/stigg-csharp/commit/51eb94ca8743547f248c86c825dddb54838d22a6))
* **api:** comment out promotional endpoints ([00e0690](https://github.com/stiggio/stigg-csharp/commit/00e06901a45c28aea2901eb9384481f6c594a6ef))

## 0.1.0 (2026-01-26)

Full Changelog: [v0.0.1...v0.1.0](https://github.com/stiggio/stigg-csharp/compare/v0.0.1...v0.1.0)

### Features

* **api:** api update ([a21c210](https://github.com/stiggio/stigg-csharp/commit/a21c210210d50e74a288e150b5c21a235aabb33e))
* **api:** api update ([3a47699](https://github.com/stiggio/stigg-csharp/commit/3a4769953fd112c06a75d4a8b4936792cf232e18))
* **client:** add `ToString` and `Equals` methods ([2c85b3e](https://github.com/stiggio/stigg-csharp/commit/2c85b3efffd227fc7e6d5e2dc68b3b74c97bf049))


### Chores

* change visibility of QueryString() and AddDefaultHeaders ([3c0112d](https://github.com/stiggio/stigg-csharp/commit/3c0112d03a6ba4808a7ad91f2d2367d5ef50328d))
* configure new SDK language ([225afb6](https://github.com/stiggio/stigg-csharp/commit/225afb67887d25396bfee9991185c379e1633575))
* **internal:** add copy constructor tests ([9e11ef7](https://github.com/stiggio/stigg-csharp/commit/9e11ef75badfbfd4922245a3780b0e282fb5c484))
* update SDK settings ([9385ad1](https://github.com/stiggio/stigg-csharp/commit/9385ad10243d4f24b4e18951f63a4d47fb2924ed))
