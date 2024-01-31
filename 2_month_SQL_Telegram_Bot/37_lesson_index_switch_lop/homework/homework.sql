CREATE TABLE "galleries"(
    "id" bigserial NOT NULL,
    "product_id" BIGINT NOT NULL,
    "image_path" TEXT NOT NULL,
    "thumbnail" BOOLEAN NOT NULL,
    "display_order" SMALLINT NOT NULL,
    "created_at" TIMESTAMP(0) WITH
        TIME zone NOT NULL
);
ALTER TABLE
    "galleries" ADD PRIMARY KEY("id");
CREATE TABLE "attribute_values"(
    "id" bigserial NOT NULL,
    "attribute_id" BIGINT NOT NULL,
    "attribute_value" VARCHAR(255) NOT NULL,
    "color" VARCHAR(255) NOT NULL
);
ALTER TABLE
    "attribute_values" ADD PRIMARY KEY("id");
CREATE TABLE "categories"(
    "id" bigserial NOT NULL,
    "category_name" VARCHAR(255) NOT NULL,
    "category_description" TEXT NOT NULL,
    "icon" TEXT NOT NULL,
    "image_path" TEXT NOT NULL,
    "active" BOOLEAN NOT NULL,
    "created_at" TIMESTAMP(0) WITH
        TIME zone NOT NULL,
        "updated_at" TIMESTAMP(0)
    WITH
        TIME zone NOT NULL,
        "created_by" BIGINT NOT NULL,
        "updated_by" BIGINT NOT NULL
);
ALTER TABLE
    "categories" ADD PRIMARY KEY("id");
CREATE TABLE "sells"(
    "id" bigserial NOT NULL,
    "product_id" BIGINT NOT NULL,
    "price" DOUBLE PRECISION NOT NULL,
    "quantity" SMALLINT NOT NULL
);
ALTER TABLE
    "sells" ADD PRIMARY KEY("id");
CREATE TABLE "products"(
    "id" bigserial NOT NULL,
    "product_name" VARCHAR(255) NOT NULL,
    "SKU" VARCHAR(255) NOT NULL,
    "regular_price" DECIMAL(8, 2) NOT NULL,
    "discount_price" DECIMAL(8, 2) NOT NULL,
    "quentity" INTEGER NOT NULL,
    "short_description" VARCHAR(255) NOT NULL,
    "product_description" TEXT NOT NULL,
    "product_weight" DECIMAL(8, 2) NOT NULL,
    "product_note" VARCHAR(255) NOT NULL,
    "pulished" BOOLEAN NOT NULL,
    "created_at" TIMESTAMP(0) WITH
        TIME zone NOT NULL,
        "updated_at" TIMESTAMP(0)
    WITH
        TIME zone NOT NULL,
        "created_by" BIGINT NOT NULL,
        "updated_by" BIGINT NOT NULL
);
ALTER TABLE
    "products" ADD PRIMARY KEY("id");
CREATE TABLE "product_tags"(
    "tag_id" BIGINT NOT NULL,
    "product_id" BIGINT NOT NULL
);
CREATE TABLE "tags"(
    "id" bigserial NOT NULL,
    "tag_name" VARCHAR(255) NOT NULL,
    "icon" TEXT NOT NULL,
    "created_at" TIMESTAMP(0) WITH
        TIME zone NOT NULL,
        "updated_at" TIMESTAMP(0)
    WITH
        TIME zone NOT NULL,
        "created_by" UUID NOT NULL,
        "updated_by" UUID NOT NULL
);
ALTER TABLE
    "tags" ADD PRIMARY KEY("id");
CREATE TABLE "product_categories"(
    "category_id" BIGINT NOT NULL,
    "product_id" BIGINT NOT NULL
);
CREATE TABLE "variant_attribute_values"(
    "variant_attribute_value_id" BIGINT NOT NULL,
    "attribute_value_id" BIGINT NOT NULL
);
CREATE TABLE "attributes"(
    "id" bigserial NOT NULL,
    "attribute_name" VARCHAR(255) NOT NULL,
    "create_at" TIMESTAMP(0) WITH
        TIME zone NOT NULL,
        "updated_at" TIMESTAMP(0)
    WITH
        TIME zone NOT NULL,
        "created_by" BIGINT NOT NULL,
        "updated_by" BIGINT NOT NULL
);
ALTER TABLE
    "attributes" ADD PRIMARY KEY("id");
CREATE TABLE "variants"(
    "id" bigserial NOT NULL,
    "variant_attribute_value_id" BIGINT NOT NULL,
    "product_id" BIGINT NOT NULL
);
ALTER TABLE
    "variants" ADD PRIMARY KEY("id");
CREATE TABLE "variant_values"(
    "id" bigserial NOT NULL,
    "variant_id" BIGINT NOT NULL,
    "price" DECIMAL(8, 2) NOT NULL,
    "quantity" INTEGER NOT NULL
);
CREATE TABLE "product_attributes"(
    "product_id" BIGINT NOT NULL,
    "attribute_id" BIGINT NOT NULL
);
ALTER TABLE
    "attribute_values" ADD CONSTRAINT "attribute_values_attribute_id_foreign" FOREIGN KEY("attribute_id") REFERENCES "attributes"("id");
ALTER TABLE
    "variants" ADD CONSTRAINT "variants_product_id_foreign" FOREIGN KEY("product_id") REFERENCES "products"("id");
ALTER TABLE
    "product_tags" ADD CONSTRAINT "product_tags_tag_id_foreign" FOREIGN KEY("tag_id") REFERENCES "tags"("id");
ALTER TABLE
    "product_attributes" ADD CONSTRAINT "product_attributes_attribute_id_foreign" FOREIGN KEY("attribute_id") REFERENCES "attributes"("id");
ALTER TABLE
    "variants" ADD CONSTRAINT "variants_variant_attribute_value_id_foreign" FOREIGN KEY("variant_attribute_value_id") REFERENCES "variant_attribute_values"("variant_attribute_value_id");
ALTER TABLE
    "sells" ADD CONSTRAINT "sells_product_id_foreign" FOREIGN KEY("product_id") REFERENCES "products"("id");
ALTER TABLE
    "variant_values" ADD CONSTRAINT "variant_values_variant_id_foreign" FOREIGN KEY("variant_id") REFERENCES "variants"("id");
ALTER TABLE
    "product_attributes" ADD CONSTRAINT "product_attributes_product_id_foreign" FOREIGN KEY("product_id") REFERENCES "products"("id");
ALTER TABLE
    "sells" ADD CONSTRAINT "sells_product_id_foreign" FOREIGN KEY("product_id") REFERENCES "products"("id");
ALTER TABLE
    "product_tags" ADD CONSTRAINT "product_tags_product_id_foreign" FOREIGN KEY("product_id") REFERENCES "products"("id");
ALTER TABLE
    "galleries" ADD CONSTRAINT "galleries_product_id_foreign" FOREIGN KEY("product_id") REFERENCES "products"("id");
ALTER TABLE
    "product_categories" ADD CONSTRAINT "product_categories_category_id_foreign" FOREIGN KEY("category_id") REFERENCES "categories"("id");
ALTER TABLE
    "variant_attribute_values" ADD CONSTRAINT "variant_attribute_values_attribute_value_id_foreign" FOREIGN KEY("attribute_value_id") REFERENCES "attribute_values"("id");
ALTER TABLE
    "product_categories" ADD CONSTRAINT "product_categories_product_id_foreign" FOREIGN KEY("product_id") REFERENCES "products"("id");

CREATE TABLE "cards"(
    "card_id" BIGINT NOT NULL,
    "customer_id" BIGINT NOT NULL
);
CREATE TABLE "product_coupons"(
    "coupon_id" BIGINT NOT NULL,
    "product_id" BIGINT NOT NULL
);
CREATE TABLE "orders"(
    "id" bigserial NOT NULL,
    "coupon_id" BIGINT NOT NULL,
    "customer_id" BIGINT NOT NULL,
    "order_status_id" BIGINT NOT NULL,
    "order_approved_at" TIMESTAMP(0) WITH
        TIME zone NOT NULL,
        "order_delivered_carrier_date" TIMESTAMP(0)
    WITH
        TIME zone NOT NULL,
        "order_delivered_customer_date" TIMESTAMP(0)
    WITH
        TIME zone NOT NULL,
        "created_at" TIMESTAMP(0)
    WITH
        TIME zone NOT NULL
);
ALTER TABLE
    "orders" ADD PRIMARY KEY("id");
CREATE TABLE "card_items"(
    "id" bigserial NOT NULL,
    "card_id" BIGINT NOT NULL,
    "product_id" BIGINT NOT NULL,
    "quantity" SMALLINT NOT NULL,
    "shopping_id" BIGINT NOT NULL
);
ALTER TABLE
    "card_items" ADD PRIMARY KEY("id");
CREATE TABLE "shoppings"(
    "id" SERIAL NOT NULL,
    "name" TEXT NOT NULL,
    "active" BOOLEAN NOT NULL,
    "icon_path" TEXT NOT NULL,
    "created_at" TIMESTAMP(0) WITH
        TIME zone NOT NULL,
        "updated_at" TIMESTAMP(0)
    WITH
        TIME zone NOT NULL,
        "created_by" BIGINT NOT NULL,
        "updated_by" BIGINT NOT NULL
);
ALTER TABLE
    "shoppings" ADD PRIMARY KEY("id");
CREATE TABLE "customer"(
    "id" bigserial NOT NULL,
    "first_name" VARCHAR(255) NOT NULL,
    "email" VARCHAR(255) NOT NULL,
    "password_hash" TEXT NOT NULL,
    "active" BOOLEAN NOT NULL,
    "registered_at" TIMESTAMP(0) WITH
        TIME zone NOT NULL,
        "created_at" TIMESTAMP(0)
    WITH
        TIME zone NOT NULL
);
ALTER TABLE
    "customer" ADD PRIMARY KEY("id");
CREATE TABLE "customers_address"(
    "id" bigserial NOT NULL,
    "customer_id" BIGINT NOT NULL,
    "address_line1" VARCHAR(255) NOT NULL,
    "postal_code" VARCHAR(255) NOT NULL,
    "country" VARCHAR(255) NOT NULL,
    "city" VARCHAR(255) NOT NULL,
    "phone_number" VARCHAR(255) NOT NULL
);
ALTER TABLE
    "customers_address" ADD PRIMARY KEY("id");
CREATE TABLE "product_shoppings"(
    "product_id" BIGINT NOT NULL,
    "shopping_id" BIGINT NOT NULL,
    "ship_charge" DECIMAL(8, 2) NOT NULL,
    "free" BOOLEAN NOT NULL,
    "estimated_days" DECIMAL(8, 2) NOT NULL
);
CREATE TABLE "order_statuses"(
    "id" bigserial NOT NULL,
    "status_name" VARCHAR(255) NOT NULL,
    "color" VARCHAR(255) NOT NULL,
    "privacy" VARCHAR(255) NOT NULL,
    "created_at" TIMESTAMP(0) WITH
        TIME zone NOT NULL,
        "updated_at" TIMESTAMP(0)
    WITH
        TIME zone NOT NULL,
        "created_by" BIGINT NOT NULL,
        "updated_by" BIGINT NOT NULL
);
ALTER TABLE
    "order_statuses" ADD PRIMARY KEY("id");
CREATE TABLE "coupons"(
    "id" BIGINT NOT NULL,
    "code" VARCHAR(255) NOT NULL,
    "coupon_description" TEXT NOT NULL,
    "discount_value" DECIMAL(8, 2) NOT NULL,
    "discount_type" VARCHAR(255) NOT NULL,
    "times_used" INTEGER NOT NULL,
    "max_usage" INTEGER NOT NULL,
    "coupon_start_date" TIMESTAMP(0) WITH
        TIME zone NOT NULL,
        "coupon_start_date" TIMESTAMP(0)
    WITH
        TIME zone NOT NULL,
        "created_at" TIMESTAMP(0)
    WITH
        TIME zone NOT NULL,
        "updated_at" TIMESTAMP(0)
    WITH
        TIME zone NOT NULL,
        "created_by" BIGINT NOT NULL,
        "updated_by" BIGINT NOT NULL
);
ALTER TABLE
    "coupons" ADD PRIMARY KEY("id");
ALTER TABLE
    "orders" ADD CONSTRAINT "orders_order_status_id_foreign" FOREIGN KEY("order_status_id") REFERENCES "order_statuses"("id");
ALTER TABLE
    "orders" ADD CONSTRAINT "orders_coupon_id_foreign" FOREIGN KEY("coupon_id") REFERENCES "coupons"("code");
ALTER TABLE
    "customers_address" ADD CONSTRAINT "customers_address_customer_id_foreign" FOREIGN KEY("customer_id") REFERENCES "customer"("id");
ALTER TABLE
    "cards" ADD CONSTRAINT "cards_customer_id_foreign" FOREIGN KEY("customer_id") REFERENCES "customer"("id");
ALTER TABLE
    "product_shoppings" ADD CONSTRAINT "product_shoppings_shopping_id_foreign" FOREIGN KEY("shopping_id") REFERENCES "shoppings"("id");
ALTER TABLE
    "product_coupons" ADD CONSTRAINT "product_coupons_coupon_id_foreign" FOREIGN KEY("coupon_id") REFERENCES "coupons"("id");
ALTER TABLE
    "card_items" ADD CONSTRAINT "card_items_shopping_id_foreign" FOREIGN KEY("shopping_id") REFERENCES "shoppings"("id");
ALTER TABLE
    "cards" ADD CONSTRAINT "cards_card_id_foreign" FOREIGN KEY("card_id") REFERENCES "card_items"("id");
ALTER TABLE
    "orders" ADD CONSTRAINT "orders_customer_id_foreign" FOREIGN KEY("customer_id") REFERENCES "customer"("id");