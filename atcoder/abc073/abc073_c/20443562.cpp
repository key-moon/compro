// detail: https://atcoder.jp/contests/abc073/submissions/20443562
#include<bits/stdc++.h>
using ll = long long;
#define var auto
const char newl = '\n';

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int main() {
  int n;
  cin >> n;
  unordered_set<int> st{};
  for (int i = 0; i < n; i++) {
    int a;
    cin >> a;
    if (st.count(a)) st.erase(a);
    else st.insert(a);
  }
  cout << st.size() << endl;
}
