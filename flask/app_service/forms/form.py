import re


def is_correct(pattern, string):
    if re.match(pattern, string):
        return True
    else:
        return False


def validate_name(string):
    pattern = r'\w+'


def validate_password(string):
    pattern = r'^[a-zA-Z]\w{3,14}$'
    return is_correct(pattern, string)


def validate_role(string):
    pattern = r'\w+'
    return is_correct(pattern, string)


def validate_login(string):
    pattern = r'[A-Z][a-z]+'
    return is_correct(pattern, string)


def validate_email(string):
    pattern = r'^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$'
    return is_correct(pattern, string)

if __name__ == '__main__':
    print validate_role('')
