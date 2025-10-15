document.getElementById("loadDogsBtn").addEventListener("click", loadDogs);

async function loadDogs() {
    const container = document.getElementById("dogContainer");
    container.innerHTML = `<div class="text-center text-secondary">Loading dogs...</div>`;

    try {
        const response = await fetch("https://api.thedogapi.com/v1/breeds");
        const breeds = await response.json();
        
        const randomBreeds = breeds.sort(() => 0.5 - Math.random()).slice(0, 8);

        container.innerHTML = "";

        const getImageUrl = (breed) => {
            if (breed.image?.url) return breed.image.url;
            if (breed.reference_image_id)
                return `https://cdn2.thedogapi.com/images/${breed.reference_image_id}.jpg`;
            return "https://via.placeholder.com/300x200?text=No+Image";
        };

        randomBreeds.forEach(breed => {
            const card = document.createElement("div");
            card.className = "col-md-4 col-lg-3";

            card.innerHTML = `
                <div class="card shadow-sm border-0 rounded-4 h-100">
                    <img src="${getImageUrl(breed)}"
                         class="card-img-top rounded-top-4" alt="${breed.name}">
                    <div class="card-body text-center">
                        <h5 class="card-title mb-1">${breed.name}</h5>
                        <p class="card-text text-muted mb-2">
                            ${breed.bred_for || "No description available"}
                        </p>
                        <p class="card-text small text-secondary">
                            Height: ${breed.height.metric} cm <br>
                            Weight: ${breed.weight.metric} kg <br>
                            Temperament: ${breed.temperament || "Unknown"}
                        </p>
                    </div>
                </div>
            `;

            container.appendChild(card);
        });

    } catch (error) {
        console.error("Error loading dogs:", error);
        container.innerHTML = `<div class="alert alert-danger text-center">
            ⚠️ Failed to load dog data. (${error.message})
        </div>`;
    }
}