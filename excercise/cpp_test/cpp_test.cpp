// cpp_test.cpp : Defines the entry point for the console application.
//

#include <algorithm>
#include <iostream>
#include <numeric>
#include <functional>
#include <iterator>
#include <vector>


template <class F, class V, class C>
auto foldl(F f, V v, C c)  -> V
{
  for (auto& x : c)
  {
    v = f(v, x);
  }
  return v;
}

template <typename I>
void qsort(I f, I l)
{
  if (f == l || f + 1 == l) return;
  auto pv = f;
  auto mid = f;
  for ( auto i = mid+1; i != l; ++i )
  {
    if ( *i < *pv )
    {
		++mid;
		std::swap(*mid, *i);
    }
  }

  std::swap(*mid, *f);
  qsort(f, mid);
  qsort(mid+1, l);
}

template <typename I>
void reverse(I f, I l)
{
}

template <typename I>
void subrange_sort(I f, I l, I sf, I sl)
{
}

int main()
{
  auto& gen = [] (auto& acc, auto a) {
    acc.push_back(acc.size());
    return acc;
  };
  auto arr = std::vector<int>(10, 1);
  auto sort_sample = foldl(gen, std::vector<int>(), arr);
  std::random_shuffle(sort_sample.begin(), sort_sample.end());
  qsort(sort_sample.begin(), sort_sample.end());
  for (auto i=sort_sample.begin(); i!= sort_sample.end(); ++i )
    std::cout << *i << ", ";
  return 0;
}

