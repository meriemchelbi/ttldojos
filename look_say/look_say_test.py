import pytest
from look_and_say import look_and_say

def test_for_input_1():
    fixture = look_and_say(1)
    assert fixture == '11'

def test_for_input_2():
    fixture = look_and_say(2)
    assert fixture == '12'