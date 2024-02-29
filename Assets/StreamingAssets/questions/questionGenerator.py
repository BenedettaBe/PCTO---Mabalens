import openai 

# Set your OpenAI API key
openai.api_key = 'YOUR_APIKEY'

# Initialize conversation with a system message
messages = [{"role": "system", "content": "You are an intelligent assistant."}]

# Get the topic from the user
argument = input("Enter the topic for the question: ")

# Iterate through 200 rounds of conversation
for x in range(200):
    # Set the difficulty level based on the iteration count
    if x <= 100:
        level = "easy"
    else:
        level = "mid"

    # Construct a user message to generate a question
    message = f"Generate a {level} level question. Provide the correct answer and three incorrect answers. Topic: {argument}. Ensure questions are distinct and answers are brief."
    
    if message: 
        messages.append({"role": "user", "content": message}) 

        # Create a chat completion using the OpenAI API
        chat = openai.ChatCompletion.create(model="gpt-3.5-turbo", messages=messages)

    # Get the assistant's reply
    reply = chat.choices[0].message.content 
    print(reply)

    # Write the generated question and answer to a file
    with open(f'{argument}.txt', 'a') as file:
        file.write(f"{reply}\n")

    # Append the assistant's reply to the conversation
    messages.append({"role": "assistant", "content": reply})
