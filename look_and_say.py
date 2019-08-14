# https://en.wikipedia.org/wiki/Look-and-say_sequence
# https://www.rosettacode.org/wiki/Look-and-say_sequence

# convert input to list
def input_to_list(input):
    input = str(input)
    sequence = [int(d) for d in input]
    print('input_to_list', sequence)
    return sequence

# group sequence elements of same value    
def group_numbers(sequence):
    
    groups_list = []
    group = []
    
    for element in sequence:
        
        if sequence[0] == sequence[1]:
            group.append(sequence[0])
            del sequence[0]
            print('sequence after equal:', sequence)
        
        if sequence[0] != sequence[1]: 
            group.append(sequence[0])
            del sequence[0]
            groups_list.append(group)
            group = []
            print('SEQUENCE if not equal:', sequence)
            
            continue
    
            # seems to be stopping loop after a couple of iterations. Work out why?    
    print('groups_list:', groups_list)
    return groups_list

# translate group of elements to results
def translate_groups(groups):
    result = ''
    for group in groups:
        result += f'{len(group)}{group[0]}'
        print('translate_group:', result)
    return result


def look_and_say(input):
    result = ''
    sequence = input_to_list(input)
    groups = group_numbers(sequence)
    translation = translate_groups(groups)
    return translation

input = 11122322521
print('input:', input)

output = look_and_say(input)
print(output)

