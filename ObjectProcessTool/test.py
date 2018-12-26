def convert(entity):
    entity.Tags['parent']=11920
    return entity

def convert(entity):
    entity.Tags['otype']=entity.Tags['name']
    return entity

def select(sobject):
    if sobject.id==77286559744:
        return True
    return False

def convert(entity):
    entity.Tags['otypename']=entity.Tags['name']
    entity.Tags['parentid']=889
    entity.Tags['height']=90
    entity.Tags['minheight']=9

    

    return entity


def convert(entity):
    entity.Tags['otypename']=entity.Tags['name']
    entity.Tags['parentid']=889
    if entity.Tags['name'] == '餐位':
        entity.Tags['height'] = 0.5
    else:
        entity.Tags['height']=4
    entity.Tags['minheight']=0


def convert(entity):
    entity.Tags['otypename']=entity.Tags['name']
    entity.Tags['parentid']=2959484100608
    if entity.Tags['name'] == '餐位':
        entity.Tags['height'] = 0.5
    elif entity.Tags['name'] == '排风井':
        entity.Tags['height'] = 0.5
    elif entity.Tags['name'] == '服务设施':
        entity.Tags['height'] = 1.5
    elif entity.Tags['name'] == '疏散楼梯':
        entity.Tags['height'] = 24
    elif entity.Tags['name'] == '电梯':
        entity.Tags['height'] = 24
    elif entity.Tags['name'] == '消防电梯':
        entity.Tags['height'] = 24
    elif entity.Tags['name'] == '无障碍电梯':
        entity.Tags['height'] = 24
    else:
        entity.Tags['height']=4
    entity.Tags['minheight']=0