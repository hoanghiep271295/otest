update class set code='C' + right(code,9) where code in (select code from grade)
GO