import json

def read_questions_file(file_path):
    # Read lines from the specified file
    with open(file_path, 'r', encoding='utf-8') as file:
        lines = file.readlines()
    return lines

def create_question_dictionary(lines):
    questions = []
    # Iterate over lines to create a list of dictionaries representing questions
    for i in range(0, len(lines), 3):
        if i + 2 < len(lines):
            question = {
                "question": lines[i].strip(),
                "correctAnswer": lines[i + 1].strip(),
                "wrongAnswer": [option.strip() for option in lines[i+2].split(',')]#build a list
            }
            questions.append(question)
    return questions

def write_json(question_dictionary, json_file_path):
    # Write the question dictionary to a JSON file
    with open(json_file_path, 'w') as json_file:
        json.dump(question_dictionary, json_file, indent=2)

if __name__ == "__main__":
    file_path = "hard.txt"
    json_file_path = "hard.json"

    lines = read_questions_file(file_path)
    question_dictionary = create_question_dictionary(lines)
    write_json(question_dictionary, json_file_path)

    print(f"The data has been written to the JSON file: {json_file_path}")
