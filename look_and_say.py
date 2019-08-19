# https://en.wikipedia.org/wiki/Look-and-say_sequence
# https://www.rosettacode.org/wiki/Look-and-say_sequence

# convert input to list
def input_to_list(input):
    input = str(input)
    sequence = [int(d) for d in input]
    return sequence

# group sequence elements of same value
# Input sequence as list    
def group_numbers(sequence):
    
    groups_list = []
    group = []
    
    while True:
        
        if len(sequence) == 1:
            group.append(sequence[0])
            groups_list.append(group)
            break

        elif sequence[0] == sequence[1]:
            group.append(sequence[0])
            del sequence[0]
        
        elif sequence[0] != sequence[1]: 
            group.append(sequence[0])
            del sequence[0]
            groups_list.append(group)
            group = []
            continue
    
    return groups_list

# translate group of elements to results
def translate_groups(groups):
    result = ''
    for group in groups:
        result += f'{len(group)}{group[0]}'
    return result

# Basic program, single input/output
def look_and_say(input):
    result = ''
    sequence = input_to_list(input)
    groups = group_numbers(sequence)
    output = translate_groups(groups)
    return output

# Loop generating Look & Say sequence based on an input, with max length set
def main_sequence(input):

    while len(str(input)) < 50:    
        output = look_and_say(input)
        print(output)
        input = output

# input = 1
# print('input:', input)

# output = look_and_say(input)
# print(output)

main_sequence(1)
