<script>
  import { ref, onMounted } from 'vue'

  export default {
    setup() {
      const customerName = ref("");
      const productName = ref("");
      const quantity = ref(0);

      const addOrder = async () => {
        try {
          const order = {
            customerName: customerName.value,
            productName: productName.value,
            quantity: quantity.value
          };

          const response = await fetch("OrderManagement/AddOrder", {
            method: "POST",
            body: JSON.stringify(order),
            headers: {
              Accept: "application/json",
              "Content-Type": "application/json",
            },
          });

          if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
          }

          alert("Order has been added!");
        }
        catch (error) {
          console.error("Error adding order:", error);
          alert("Failed to add order. Please try again.");
        }
      };

      // Call SetupSession when component loads
      onMounted(async () => {
        try {
          await fetch("OrderManagement/Setup", { method: "POST" });
          console.log("Session setup complete.");
        } catch (error) {
          console.error("Error setting up session:", error);
        }
      });

      return {
        customerName,
        productName,
        quantity,
        addOrder
      };
    }
  };
</script>

<template>
  <form class="my-form" @submit.prevent="addOrder">
    <input v-model="customerName" type="text" placeholder="Enter Customer Name" required/>
    <br />
    <input v-model="productName" type="text" placeholder="Enter Product Name" required/>
    <br />
    <p>Enter quanity number</p><br />
    <input v-model="quantity" type="number" min="1" /><br />
    <div>
      <button type="submit">Add Order</button>
    </div>
  </form>
  <br />
  <br />
  <div style="display:block">
    Name: {{ customerName }}<br />
    Product: {{ productName }}<br />
    Quantity: {{ quantity }}<br />
  </div>

</template>
