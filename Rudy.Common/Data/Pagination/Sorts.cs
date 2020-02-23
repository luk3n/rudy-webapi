﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Rudy.Common.Data.Pagination
{
    public class Sorts<T>
    {
        private readonly List<dynamic> _sortList;

        public Sorts()
        {
            _sortList = new List<dynamic>();
        }

        public void Add<TKey>(bool condition, Expression<Func<T, TKey>> expression, bool byDescending = false, int priority = 1)
        {
            Append(condition, expression, byDescending, priority);
        }

        private void Append<TKey>(bool condition, Expression<Func<T, TKey>> expression, bool byDescending = false, int priority = 1)
        {
            _sortList.Add(new Sort<T, TKey>
            {
                Condition = condition,
                Expression = expression,
                ByDescending = byDescending,
                Priority = priority
            });
        }

        internal bool IsValid()
        {
            return _sortList.Any(s => s.Condition);
        }

        internal static IQueryable<T> ApplySorts(IQueryable<T> query, Sorts<T> sorts)
        {
            var isFirstSort = true;
            var validSortings = sorts.GetAll();
            IOrderedQueryable<T> orderedQuery = null;

            foreach (var sort in validSortings)
            {
                orderedQuery = isFirstSort
                    ? ApplySorting(query, sort)
                    : ApplySorting(orderedQuery, sort);
                isFirstSort = false;
            }

            return orderedQuery ?? query;
        }

        private dynamic GetAll()
        {
            return _sortList.Where(s => s.Condition).OrderBy(s => s.Priority);
        }

        private static IOrderedQueryable<T> ApplySorting<TKey>(IQueryable<T> query, Sort<T, TKey> sort)
        {
            return sort.ByDescending
                ? query.OrderByDescending(sort.Expression)
                : query.OrderBy(sort.Expression);
        }

        private static IQueryable<T> ApplySorting<TKey>(IOrderedQueryable<T> query, Sort<T, TKey> sort)
        {
            return sort.ByDescending
                ? query.ThenByDescending(sort.Expression)
                : query.ThenBy(sort.Expression);
        }
    }
}
