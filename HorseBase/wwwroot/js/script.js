let horsesController; // Array to store horse elements
const horses = []; // Array to store horse elements
const speed = 2; // Speed of movement
let horseCount;


document.addEventListener("DOMContentLoaded", function () {
    horsesController = GetData();
    horseCount = horsesController.length;
    spawnHorses();
    moveHorses();
});

function GetData() {

let result;
    $.ajax(
        {
            url: '/Horses/GetAllHorses',
            async: false,
            dataType: "json",
            success: (givenData) => {
                result = givenData;
            },
        });
    return result;
}


// Function to create and spawn horses
function spawnHorses() {

    const tooltip = document.createElement('div');
    tooltip.className = 'tooltip';
    tooltip.style.position = 'absolute';
    tooltip.style.backgroundColor = 'rgba(0, 0, 0, 0.7)';
    tooltip.style.color = 'white';
    tooltip.style.padding = '10px';
    tooltip.style.borderRadius = '5px';
    tooltip.style.display = 'none'; // Initially hidden
    tooltip.style.opacity = '100';
    document.body.appendChild(tooltip);

    for (let i = 0; i < horseCount; i++) {
        const horse = document.createElement('img');
        horse.src = horsesController[i].breed.url; // Correct path to horse image
        horse.className = 'horse';
        horse.style.left = `${Math.random() * window.innerWidth}px`;
        horse.style.top = `${Math.random() * window.innerHeight}px`;
        document.body.appendChild(horse);

        // Add to array with initial properties
        horses.push({
            element: horse,
            x: Math.random() * window.innerWidth,
            y: Math.random() * window.innerHeight,
            directionX: Math.random() < 0.5 ? -1 : 1,
            directionY: Math.random() < 0.5 ? -1 : 1,
            isResting: false, // Flag to determine if horse is resting
            isHovered: false,
            rotationAngle: 0, // Current tilt angle for rotation animation
            info: horsesController[i]
        });

        // Add hover event listeners
        horse.addEventListener('mouseover', (event) => {
            horses[i].isHovered = true; // Stop movement
            tooltip.style.display = 'block';
            tooltip.innerHTML = `
                <strong>Horse Number:</strong> ${horses[i].info.number} <br>
                <strong>Breed:</strong> ${horses[i].info.breed.name} <br>
                <strong>Price:</strong> ${horses[i].info.price} <br>
                <strong>Height:</strong> ${horses[i].info.height} <br>
                <strong>Year of Birth:</strong> ${horses[i].info.birhtYear.toString().substring(0,10)}
            `;

            // Update tooltip position near mouse cursor
            updateTooltipPosition(event);


        });

        horse.addEventListener('mousemove', (event) => {
            if (horses[i].isHovered) {
                updateTooltipPosition(event);
            }
        });

        horse.addEventListener('mouseout', () => {
            horses[i].isHovered = false; // Resume movement
            tooltip.style.display = 'none';
        });
    }
}
function updateTooltipPosition(event) {
    const tooltip = document.querySelector('.tooltip');
    tooltip.style.left = `${event.pageX + 10}px`; // Slightly to the right of the cursor
    tooltip.style.top = `${event.pageY + 10}px`; // Slightly below the cursor
}

// Function to move all horses
function moveHorses() {
    horses.forEach((horseData) => {
        const horse = horseData.element;

        // Handle resting behavior
        if (horseData.isResting) {
            // Randomly decide to stop resting
            if (Math.random() < 0.01) {
                horseData.isResting = false;
                horse.style.transition = 'transform 0.2s'; // Reset for smooth motion
            }
            return; // Skip movement while resting
        }

        // Randomly decide to rest
        if (Math.random() < 0.005 || horseData.isHovered == true) {
            horseData.isResting = true;
            horse.style.transition = 'transform 1s'; // Smooth transition to rest
            horse.style.transform = 'rotate(0deg)'; // Reset rotation during rest
            return;
        }

        // Randomly change direction less frequently
        if (Math.random() < 0.01) {
            horseData.directionX = Math.random() < 0.5 ? -1 : 1;
            horseData.directionY = Math.random() < 0.5 ? -1 : 1;

            // Flip the horse sprite based on direction
            horse.style.transform = horseData.directionX === -1
                ? `scaleX(-1) rotate(${horseData.rotationAngle}deg)`
                : `scaleX(1) rotate(${horseData.rotationAngle}deg)`;
        }

        // Update position
        horseData.x += horseData.directionX * speed;
        horseData.y += horseData.directionY * speed;

        // Handle screen boundaries
        if (horseData.x < 0) {
            horseData.x = 0;
            horseData.directionX = 1;
        } else if (horseData.x + horse.width > window.innerWidth) {
            horseData.x = window.innerWidth - horse.width;
            horseData.directionX = -1;
        }
        if (horseData.y < 0) {
            horseData.y = 0;
            horseData.directionY = 1;
        } else if (horseData.y + horse.height > window.innerHeight) {
            horseData.y = window.innerHeight - horse.height;
            horseData.directionY = -1;
        }

        // Rotate the horse slightly left and right to mimic movement
        horseData.rotationAngle += horseData.directionX * 0.5; // Adjust the tilt angle
        if (Math.abs(horseData.rotationAngle) > 20) {
            horseData.rotationAngle = 0; // Reset after reaching a tilt limit
        }

        // Apply position and rotation
        horse.style.left = `${horseData.x}px`;
        horse.style.top = `${horseData.y}px`;
        horse.style.transform = horseData.directionX === -1
            ? `scaleX(-1) rotate(${horseData.rotationAngle}deg)`
            : `scaleX(1) rotate(${horseData.rotationAngle}deg)`;
    });

    // Continue animation
    requestAnimationFrame(moveHorses);



}
